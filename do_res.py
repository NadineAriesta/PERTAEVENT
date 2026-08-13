import re

with open('temp_card.txt', 'r', encoding='utf-8') as f:
    inner = f.read()

# Fix inner variables
inner = inner.replace('status != "Menunggu Konfirmasi"', 'statusLabel != "Menunggu Konfirmasi"')
inner = inner.replace('@progress', '@pct')
inner = inner.replace('(progress)', '(pct)')
inner = inner.replace('progress == 100', 'pct == 100')
inner = inner.replace('TerimaPenugasan(assign)', 'Task.CompletedTask')
inner = inner.replace('OnOpenUpload.InvokeAsync(assign)', 'Task.CompletedTask')
inner = inner.replace('@onclick="() => SimpanProgress(assign)"', '@onclick="async () => await SimpanProgress(assign)"')
inner = inner.replace('@onclick="() => ToggleKebutuhan', '@onclick="async () => await ToggleKebutuhan')

replacement = '''<div class="col-12">
                            @{ bool isAllReturned = assign.Acara?.Kebutuhan != null && assign.Acara.Kebutuhan.Any() && assign.Acara.Kebutuhan.All(k => k.IsKembali); }
                            ''' + inner + '''
                            </div>'''

with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

# Replace the 2 instances
pattern = re.compile(r'<div class="col-12">.*?</div>\n\s*</div>\n\s*</div>\n\s*</div>\n\s*</div>\n\s*</div>', re.DOTALL)
text = pattern.sub(replacement, text)

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)

print("Done substituting.")
