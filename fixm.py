import re

with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

text = text.replace('OpenUploadModalAdmin(assign)', 'Task.CompletedTask')
text = text.replace('OpenUploadModalAdmin', '')

text = text.replace('isAllReturned', '(assign.Acara?.Kebutuhan != null && assign.Acara.Kebutuhan.Any() && assign.Acara.Kebutuhan.All(ka => ka.IsKembali))')
# also remove ool (assign.Acara?.Kebutuhan != null && assign.Acara.Kebutuhan.Any() && assign.Acara.Kebutuhan.All(ka => ka.IsKembali)) = ...
text = re.sub(r'bool \(\s*assign\.Acara\?\.Kebutuhan [^;]+;', '', text)

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)

print('Fixed.')
