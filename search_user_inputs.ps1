# Resolve user profile dynamically
$userProfile = $env:USERPROFILE
if ([string]::IsNullOrEmpty($userProfile)) {
    $userProfile = "C:\Users\lenovo"
}
$brainDir = Join-Path $userProfile ".gemini\antigravity\brain"
$defaultConvId = "de4ec850-534d-409b-9b76-a107addfbf47"
$logPath = Join-Path $brainDir "$defaultConvId\.system_generated\logs\overview.txt"

if (-not (Test-Path $logPath)) {
    Write-Host "[INFO] Path log default untuk $defaultConvId tidak ditemukan."
    if (Test-Path $brainDir) {
        $overviewFiles = Get-ChildItem -Path $brainDir -Filter "overview.txt" -Recurse -File
        if ($overviewFiles) {
            # Sort by LastWriteTime descending
            $overviewFiles = $overviewFiles | Sort-Object LastWriteTime -Descending
            $logPath = $overviewFiles[0].FullName
            $convId = Split-Path (Split-Path (Split-Path (Split-Path $logPath -Parent) -Parent) -Parent) -Leaf
            Write-Host "[INFO] Menggunakan log percakapan terbaru: $convId"
        } else {
            Write-Error "ERROR: Tidak ditemukan file overview.txt di $brainDir"
            exit 1
        }
    } else {
        Write-Error "ERROR: Direktori brain $brainDir tidak ditemukan."
        exit 1
    }
}

$lines = Get-Content $logPath
foreach ($line in $lines) {
    if (-not [string]::IsNullOrWhiteSpace($line)) {
        try {
            $json = $line | ConvertFrom-Json -ErrorAction Stop
            if ($json.source -eq "USER_EXPLICIT" -or $json.type -eq "USER_INPUT") {
                Write-Output "----------------------------------------"
                Write-Output "STEP INDEX: $($json.step_index) | TYPE: $($json.type)"
                Write-Output "CONTENT: $($json.content)"
            }
        } catch {
            # Ignore malformed JSON lines
        }
    }
}
