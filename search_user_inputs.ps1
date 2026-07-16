$logPath = "C:\Users\asus\.gemini\antigravity\brain\de4ec850-534d-409b-9b76-a107addfbf47\.system_generated\logs\overview.txt"
$lines = Get-Content $logPath
foreach ($line in $lines) {
    $json = $line | ConvertFrom-Json
    if ($json.source -eq "USER_EXPLICIT" -or $json.type -eq "USER_INPUT") {
        Write-Output "----------------------------------------"
        Write-Output "STEP INDEX: $($json.step_index) | TYPE: $($json.type)"
        Write-Output "CONTENT: $($json.content)"
    }
}
