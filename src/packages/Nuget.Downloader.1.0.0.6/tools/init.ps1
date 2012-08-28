
function global:Download-Packages {  
 param (
	[string] $feedUrlBase = "http://go.microsoft.com/fwlink/?LinkID=206669",
	[bool] $latest = $true,
 	[bool] $overwrite = $false,
 	 $top = 500, #use $null to download all  
 	[string] $destinationDirectory = (join-path ([Environment]::GetFolderPath("MyDocuments")) "NuGetLocal"  )    
	)

 
 # --- locals --- 
 $webClient = New-Object System.Net.WebClient   
 $feedUrl = ""
 
function DownloadEntries {  
 param ([string]$feedUrl)
    "downloading from $feedUrl"
 
    $feed = [xml]$webClient.DownloadString($feedUrl)  
    $entries = $feed | select -ExpandProperty feed | select -ExpandProperty entry  
    $progress = 0   
    foreach ($entry in $entries) { 
       $url = $entry.content.src     
       $fileName = $entry.properties.id + "." + $entry.properties.version + ".nupkg"    
       $saveFileName = join-path $destinationDirectory $fileName    
       $pagepercent = ((++$progress)/$entries.Length*100)
       if ((-not $overwrite) -and (Test-Path -path $saveFileName))      {     
           write-progress -activity "$fileName already downloaded" -status "$pagepercent% of current page complete" -percentcomplete $pagepercent      
           continue     
        }  
        write-progress -activity "Downloading $fileName" -status "$pagepercent% of current page complete" -percentcomplete $pagepercent
        $webClient.DownloadFile($url, $saveFileName)   
      }
     $link = $feed.feed.link | where { $_.rel.startsWith("next") } | select href   
     if ($link -ne $null) {     
         # if using a paged url with a $skiptoken like      
         # http:// ... /Packages?$skiptoken='EnyimMemcached-log4net','2.7'     
         # remember that you need to escape the $ in powershell with `     
         $feedUrl = $link.href     
         DownloadEntries $feedUrl  
     } 
  }     
     # the NuGet feed uses a fwlink which redirects 
     # using this to follow the redirect 
     function GetPackageUrl {  
     param ([string]$feedUrlBase)   
     $resp = [xml]$webClient.DownloadString($feedUrlBase)  
     return $resp.service.GetAttribute("xml:base") 
     }   
     
     # --- do the actual work ---   
     # if dest dir doesn't exist, create it 
     if (!(Test-Path -path $destinationDirectory)) { 
        New-Item $destinationDirectory -type directory 
    }
        
    # set up feed URL 
    $serviceBase = GetPackageUrl($feedUrlBase) 
    $feedUrl = $serviceBase + "Packages"
    if($latest) {     
        $feedUrl = $feedUrl + "?`$filter=IsLatestVersion eq true"   
        if($top -ne $null) {        
			"Downloading top $top packages (by download count)"
            $feedUrl = $feedUrl + "&`$orderby=DownloadCount desc&`$top=$top"    
        } 
    }   
    
    DownloadEntries $feedUrl
	"Complete. Local packages saved to $destinationDirectory"
}        