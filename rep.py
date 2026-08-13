import re

with open('temp_card.txt', 'r', encoding='utf-8') as f:
    inner = f.read()
    
# Remove <div class="tek-card ...> at the start and </div> at the end
start = inner.find('<div class="tek-card')
inner = inner[start:]

# Replace status != "Menunggu Konfirmasi" with 	rue (so admin always can execute, or statusLabel != "Menunggu Konfirmasi")
inner = inner.replace('status != "Menunggu Konfirmasi"', 'statusLabel != "Menunggu Konfirmasi"')

# Replace progress with pct
inner = inner.replace('@progress', '@pct')
inner = inner.replace('(progress)', '(pct)')
inner = inner.replace('progress == 100', 'pct == 100')

# Replace TerimaPenugasan button branch since Admin/Helpdesk shouldn't "Terima Penugasan"?
# Actually, the user says "biar cepet samakan", let's leave it as is but use ssign.Progress.
clean_code = '''<div class="col-12">
''' + inner + '''
</div>'''

# We need to replace the col-12 in Home.razor.
# Let's find exactly the range of lines to replace to avoid regex issues.
with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    lines = f.readlines()

out = []
in_col12 = 0
skip = False
for line in lines:
    if 'var statusLabel = assign.StatusPenugasan;' in line:
        out.append(line)
        skip = True
        out.append(clean_code)
        continue
        
    if skip:
        if '<div class="col-12">' in line:
            in_col12 += 1
        if '</div>' in line and in_col12 > 0:
            in_col12 -= 1
            if in_col12 == 0:
                skip = False
        continue
    
    if not skip:
        out.append(line)

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.writelines(out)
    
print("Code successfully replaced!")
