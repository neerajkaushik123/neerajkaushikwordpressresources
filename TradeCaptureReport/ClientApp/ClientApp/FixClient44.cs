using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX44;
using QuickFix.Transport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TradingClientApp.Model;
using Message = QuickFix.Message;

namespace TradingClientApp
{
	public class FixClient44 : MessageCracker, QuickFix.IApplication
	{
		private IInitiator initiator;
		private SessionID _currentSessionId;
		private readonly SessionID _markedDataSession;

		public event Action<Security> OnSecurity;
		public event Action<MarketPrice> OnMarketPrice;

		public List<Security> Securities { get; private set; }

		public event Action<string> OnProgress;
		/// <summary>
		/// InitializSession
		/// </summary>
		public Task Initialize(Action<string> progress, CancellationToken cancellationToken)
		{
			return Task.Run(() =>

			{
				var settings = new SessionSettings("cts.cfg");

				IMessageStoreFactory messageFactory = new FileStoreFactory(settings);

				ILogFactory logFactory = new FileLogFactory(settings);

				initiator = new SocketInitiator(this, messageFactory, settings, logFactory);

				progress("Initialization done");

			}, cancellationToken);
		}

		public void Connect()
		{
			initiator.Start();
		}

		public void Disconnect()
		{
			initiator.Stop();
		}

		public void FromAdmin(Message message, SessionID sessionID)
		{
			if (message is QuickFix.FIX44.Heartbeat)
			{
				OnProgress("Heartbeat");
			}
		}

		public void FromApp(Message message, SessionID sessionID)
		{
			//All Incoming Applications message trigger here
			Crack(message, sessionID);
		}

		public void OnCreate(SessionID sessionID)
		{
			OnProgress("Session created");
		}

		//if logon is successful
		public void OnLogon(SessionID sessionID)
		{
			_currentSessionId = sessionID;
			OnProgress("Connection is successful");
			// throw new NotImplementedException();
		}

		//if logon is failed
		public void OnLogout(SessionID sessionID)
		{
			OnProgress("Connection is loggedout");
		}

		//hook admin messages before calling server
		public void ToAdmin(Message message, SessionID sessionID)
		{
			if (message is QuickFix.FIX44.Logon)
			{
				var logon = message as QuickFix.FIX44.Logon;

				//logon.SetField(new StringField(553, "AAA")); //username
				//logon.SetField(new StringField(554, "XXX")); //username

			}
		}

		public void ToApp(Message message, SessionID sessionId)
		{
			//  throw new NotImplementedException();
		}

		//Send Security Definitions Request
		public Task SendSecurityDefinitionRequest(Action<string> progressHandler)
		{
			return Task.Run(() =>
			{
				//Create object of Security Definition
				QuickFix.FIX44.SecurityDefinitionRequest securityDefinition = new QuickFix.FIX44.SecurityDefinitionRequest();
				securityDefinition.SecurityReqID = new SecurityReqID(Guid.NewGuid().ToString());
				securityDefinition.SecurityExchange = new SecurityExchange("ICDX");
				securityDefinition.SecurityRequestType = new SecurityRequestType(SecurityListRequestType.TRADINGSESSIONID);
				Session.SendToTarget(securityDefinition, _currentSessionId);
				progressHandler("Sent Security Definition Request");
			});
		}

		public Task SendTradeCaptureRequest(DateTime startDateTime, DateTime endDateTime, Action<string> progressHandler)
		{
			return Task.Run(() =>
			{
				TradeCaptureReportRequest request = new TradeCaptureReportRequest();
				string requestId = DateTime.UtcNow.ToString("yyMMddHHmmssfff");
				request.TradeRequestID = new TradeRequestID(requestId);
				request.TradeRequestType = new TradeRequestType(TradeRequestType.MATCHED_TRADES_MATCHING_CRITERIA_PROVIDED_ON_REQUEST);
				request.NoDates = new NoDates(2);

				var noDatesGroup = new TradeCaptureReportRequest.NoDatesGroup();
				noDatesGroup.TransactTime = new TransactTime(startDateTime);
				request.AddGroup(noDatesGroup);

				noDatesGroup = new TradeCaptureReportRequest.NoDatesGroup();
				noDatesGroup.TransactTime = new TransactTime(endDateTime);
				request.AddGroup(noDatesGroup);

				Session.SendToTarget(request, _currentSessionId);
			});
		}

		public void OnMessage(TradeCaptureReportRequestAck ackReport, SessionID session)
		{
			if (ackReport.TradeRequestStatus.getValue() == TradeRequestStatus.REJECTED)
			{
				OnProgress("TradeReportRequestStatus Rejected");
			}
			else if (ackReport.TradeRequestStatus.getValue() == TradeRequestStatus.ACCEPTED)
			{
				OnProgress("TradeReportRequestStatus Accepted");
			}
			else if (ackReport.TradeRequestStatus.getValue() == TradeRequestStatus.COMPLETED)
			{
				OnProgress("TradeReportRequestStatus COMPLETED");
			}
		}

		public Task SendMarketDataRequest(string symbol, string exchange, Action<string> progressHandler)
		{
			return Task.Run(() =>
			{
				//Create object of Security Definition
				QuickFix.FIX44.MarketDataRequest securityDefinition = new QuickFix.FIX44.MarketDataRequest
				{
					MDReqID = new MDReqID(Guid.NewGuid().ToString()),
					SubscriptionRequestType = new SubscriptionRequestType(SubscriptionRequestType.SNAPSHOT_PLUS_UPDATES),
					MarketDepth = new MarketDepth(1),
					MDUpdateType = new MDUpdateType(0)

				};

				var noMDEntryTypes = new QuickFix.FIX44.MarketDataRequest.NoMDEntryTypesGroup();
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.BID)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.OFFER)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.TRADE)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.OPENING_PRICE)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.SETTLEMENT_PRICE)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.TRADING_SESSION_HIGH_PRICE)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.TRADING_SESSION_LOW_PRICE)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.TRADE_VOLUME)); securityDefinition.AddGroup(noMDEntryTypes);
				noMDEntryTypes.Set(new MDEntryType(MDEntryType.OPEN_INTEREST)); securityDefinition.AddGroup(noMDEntryTypes);

				securityDefinition.NoRelatedSym = new NoRelatedSym(1);

				var relatedSymbol = new QuickFix.FIX44.MarketDataRequest.NoRelatedSymGroup();
				relatedSymbol.Set(new Symbol(symbol));
				relatedSymbol.Set(new SecurityExchange(exchange));
				securityDefinition.AddGroup(relatedSymbol);
				Session.SendToTarget(securityDefinition, _currentSessionId);
				progressHandler("Sent MarketData Request");
			});
		}

		public void OnMessage(QuickFix.FIX44.MarketDataRequestReject marketDataSnapshot, SessionID session)
		{
			Debug.WriteLine(marketDataSnapshot.ToString());
		}


		public void OnMessage(TradeCaptureReport ackReport, SessionID session)
		{
			TradeReport tradeReport = new TradeReport
			{
				Id = ackReport.ExecID.getValue(),
				LastQty = ackReport.LastQty.getValue(),
				TransactTime = ackReport.IsSetTransactTime() ? ackReport.TransactTime.getValue() : DateTime.UtcNow,
				LastPrice = ackReport.LastPx.getValue(),
				InstrumentId = Convert.ToInt32(ackReport.SecurityID.getValue())
			};

			NoSides noSides = ackReport.NoSides;

			tradeReport.Symbol = ackReport.Symbol.getValue();

			var group = new TradeCaptureReport.NoSidesGroup();
			group = (TradeCaptureReport.NoSidesGroup)ackReport.GetGroup(1, group);

			if (group.IsSetSide())
			{
				switch (group.Side.getValue())
				{
					case Side.BUY:
						tradeReport.Side = BuySellType.Buy;
						break;
					case Side.SELL:
						tradeReport.Side = BuySellType.Sell;
						break;
				}
			}

			tradeReport.OrderId = group.OrderID.getValue();
			tradeReport.ClientOrderId = group.ClOrdID.getValue();

			//OnTradeReportInvoke(tradeReport);

		}
		public void OnMessage(QuickFix.FIX44.MarketDataSnapshotFullRefresh marketDataSnapshot, SessionID session)
		{
			MarketPrice marketPrice = new MarketPrice
			{
				Symbol = marketDataSnapshot.Symbol.getValue()
			};
			var nomdentries = marketDataSnapshot.NoMDEntries;
			// message.GetGroup(1, noMdEntries);
			var grp = new QuickFix.FIX44.MarketDataSnapshotFullRefresh.NoMDEntriesGroup();

			for (int i = 1; i <= nomdentries.getValue(); i++)
			{
				grp = (QuickFix.FIX44.MarketDataSnapshotFullRefresh.NoMDEntriesGroup)marketDataSnapshot.GetGroup(i, grp);

				//	var grp = marketDataSnapshot.GetGroup(i, new QuickFix.FIX44.MarketDataSnapshotFullRefresh.NoMDEntriesGroup()) as QuickFix.FIX44.MarketDataSnapshotFullRefresh.NoMDEntriesGroup;
				MDEntryType priceType = grp.Get(new MDEntryType());
				MDEntryPx mdEntryPx = grp.Get(new MDEntryPx());
				if (priceType.getValue() == MDEntryType.BID)
				{
					marketPrice.Bid = mdEntryPx.getValue();
				}
				else if (priceType.getValue() == MDEntryType.OFFER)
				{
					marketPrice.Offer = mdEntryPx.getValue();
				}
				else if (priceType.getValue() == MDEntryType.TRADE)
				{
					marketPrice.TradedPrice = mdEntryPx.getValue();
				}
				else if (priceType.getValue() == MDEntryType.TRADING_SESSION_LOW_PRICE)
				{
					marketPrice.LowPx = mdEntryPx.getValue();
				}
				else if (priceType.getValue() == MDEntryType.TRADING_SESSION_HIGH_PRICE)
				{
					marketPrice.HighPx = mdEntryPx.getValue();
				}
			}

			if (OnMarketPrice != null)
			{
				OnMarketPrice(marketPrice);
			}
		}


		public void OnMessage(QuickFix.FIX44.MarketDataIncrementalRefresh marketDataSnapshot, SessionID session)
		{

		}
		///Response to Security Defintion will be triggered here
		public void OnMessage(QuickFix.FIX44.SecurityDefinition securityDefinition, SessionID session)
		{
			//Store Security Definitions
			Securities = new List<Security>();
			//Number of securities in one message
			var relatedsymbol = securityDefinition.SecurityID.getValue();

			var group = new QuickFix.FIX44.SecurityDefinition();
			if (Securities == null)
			{
				Securities = new List<Security>();
			}

			var sec = new Security
			{
				Symbol = securityDefinition.Symbol.getValue(),
				ContractMultiplier = securityDefinition.ContractMultiplier.getValue(),
				Currency = securityDefinition.Currency.getValue(),
				Exchange = securityDefinition.SecurityExchange.getValue(),
				MaturityMonthYear = securityDefinition.MaturityMonthYear.getValue()
			};

			Securities.Add(sec);

			if (OnSecurity != null)
			{
				OnSecurity(sec);
			}
		}
	}
}
