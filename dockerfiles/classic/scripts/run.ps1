#100% Pure Stackoverflow copy/paste
function XmlDocTransform($xml, $xdt)
{
    if (!$xml -or !(Test-Path -path $xml -PathType Leaf)) {
        throw "File not found. $xml";
    }
    if (!$xdt -or !(Test-Path -path $xdt -PathType Leaf)) {
        throw "File not found. $xdt";
    }

    Add-Type -LiteralPath "$PSScriptRoot\Microsoft.Web.XmlTransform.dll"

    $xmldoc = New-Object Microsoft.Web.XmlTransform.XmlTransformableDocument;
    $xmldoc.PreserveWhitespace = $true
    $xmldoc.Load($xml);

    $transf = New-Object Microsoft.Web.XmlTransform.XmlTransformation($xdt);
    if ($transf.Apply($xmldoc) -eq $false)
    {
        throw "Transformation failed."
    }
    $xmldoc.Save($xml);
}

echo "Loading WebAdministration"
Import-Module WebAdministration
echo "Stopping website"
Stop-WebSite "Default Web Site"

echo "Transforming config"
XmlDocTransform c:\inetpub\wwwroot\Web.config c:\external\config.xml

echo "Starting website"
Start-WebSite "Default Web Site"

$ip=get-WmiObject Win32_NetworkAdapterConfiguration|Where {$_.Ipaddress.length -gt 1}
$ip = $ip.ipaddress[0]
echo "IP address is $ip"

echo "Waiting forever"
while($true)
{
Sleep 100
}