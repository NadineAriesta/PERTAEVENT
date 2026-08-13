import re

with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

# We want to replace the whole block starting at <div class="col-12">
# inside the Assignments.OrderByDescending loop where ssign is the variable.
# There are 2 instances because we duplicated Laporan Progres Teknisi.
# Let's find exactly the pattern using regex dotall.
# The block ends right before } <!-- end loop --> so it's followed directly by } at an indentation space.

pattern = re.compile(r'<div class="col-12">.*?</div>\n\s*</div>\n\s*</div>\n\s*</div>\n\s*</div>\n\s*</div>', re.DOTALL)
matches = pattern.findall(text)
print("Matches found:", len(matches))

