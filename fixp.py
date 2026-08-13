import re

with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

# Fix the broken ssign.Acara inside C# function GetStatusPenugasan
text = text.replace('CalculateProgress(p) == 100 || (assign.Acara?.Kebutuhan != null && assign.Acara.Kebutuhan.Any() && assign.Acara.Kebutuhan.All(ka => ka.IsKembali)))', 'CalculateProgress(p) == 100 || (p.Acara?.Kebutuhan != null && p.Acara.Kebutuhan.Any() && p.Acara.Kebutuhan.All(ka => ka.IsKembali)))')

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)

