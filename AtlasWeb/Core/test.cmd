
for /f "delims=" %%F in ('git symbolic-ref --short -q HEAD') do set var=%%F 
ECHO %var%