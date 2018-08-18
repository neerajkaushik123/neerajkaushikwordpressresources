$strPath = "<EXCEL FILE>"
$outpath = "<OUTFILE>>"

$objExcel = New-Object -ComObject Excel.Application
$objExcel.Visible = $false

$WorkBook = $objExcel.Workbooks.Open($strPath)
$worksheet = $workbook.sheets.item("DEH List")
$intRowMax =  ($worksheet.UsedRange.Rows).count
$intColMax =  ($worksheet.UsedRange.Columns).count


<#Write "`nServer Name     Server Function     1st Contact          2nd Contact" | Out-File $AssetInv#>
Write "--------------- ------------------- -------------------- -----------------------------" | 
      Out-FIle $AssetInv -Append

Write-Host "Processing: " $intRowMax " rows" "and columns " $intColMax    

for ($intRow = 1 ; $intRow -le $intRowMax ; $intRow++) {
    
     for($col =1 ; $col -le $intColMax ; $col++) 
     {
              
            $cellValue = $worksheet.cells.item($intRow, $col).value2

             "Cell ( " + $intRow + "," + $col + ") : =" + $cellValue |
                Out-File $outpath -Append
     }
 }

$objexcel.quit()