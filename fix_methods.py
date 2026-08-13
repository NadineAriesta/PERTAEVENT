import re

with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

# Fix TerimaPenugasan block
text = re.sub(
    r'@if\s*\(statusLabel\s*==\s*"Menunggu Konfirmasi"\).*?</div>\s*</div>\s*</div>',
    '</div>',
    text,
    flags=re.DOTALL
)

# Fix open upload modal
text = text.replace('OnOpenUpload.InvokeAsync(assign)', 'Task.CompletedTask')
text = text.replace('() => TerimaPenugasan(assign)', 'Task.CompletedTask')

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)

print('Fixed methods.')
