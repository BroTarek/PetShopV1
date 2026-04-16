import os
import glob

def clean_conflict_markers(directory):
    for root, dirs, files in os.walk(directory):
        for file in files:
            if not file.endswith('.cs') and not file.endswith('.csproj') and file != 'Program.cs' and file != 'docker-compose.yml':
                continue
            
            filepath = os.path.join(root, file)
            try:
                with open(filepath, 'r', encoding='utf-8') as f:
                    content = f.read()
            except UnicodeDecodeError:
                continue

            if '<<<<<<< HEAD' not in content:
                continue

            # We want to extract the EXACT content between <<<<<<< HEAD\n and =======\n
            # Because of line ending variations (\r\n vs \n), it's safer to read line by line
            with open(filepath, 'r', encoding='utf-8') as f:
                lines = f.readlines()
            
            new_lines = []
            state = 'NORMAL' # NORMAL, IN_HEAD, IN_REMOTE
            
            for line in lines:
                if line.startswith('<<<<<<< HEAD'):
                    state = 'IN_HEAD'
                    continue
                elif line.startswith('======='):
                    state = 'IN_REMOTE'
                    continue
                elif line.startswith('>>>>>>> '):
                    state = 'NORMAL'
                    continue
                
                if state == 'NORMAL' or state == 'IN_HEAD':
                    new_lines.append(line)
            
            with open(filepath, 'w', encoding='utf-8') as f:
                f.writelines(new_lines)
            print(f"Cleaned {filepath}")

if __name__ == '__main__':
    clean_conflict_markers('.')
