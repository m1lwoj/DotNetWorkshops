# Zadanie 1 - podstawowe operacje

1. Utwórz repozytorium https://github.com/new
2. Pobierz repozytorium lokalnie `git clone`
3. Uwórz plik tekstowy
4. Sprawdź obecny status repozytorium `git status`
5. Dodaj zmiany do Staging Area `git add`  
6. Sprawdź obecny status repozytorium `git status` (jakie są różnice względem 4.)
7. Dodaj zmiany do Local Tepository `git commit`
8. Powtórz 3-7 ponownie
9. Wypchnij zmiany do zdalnego repozytorium `git push`  
10. Sprawdź zmiany w  repozytorium zdalnym (w utworzonym repozytorium na github)
11. Utwórz nowy branch "new" `git checkout -b <branch_name`
12. Zmień któryś z utworzonych plików
13. `git add`  `git commit` `git push`
14. Utwórz Pull Request
15. Zweryfikuj i zatwierdź zmiany
16. Lokalnie zmień branch na "main"  `git checkout`
17. Sprawdź obecny status repozytorium `git status`, sprawdź historię logów `git log`
18. Pobierz zmiany lokalnie `git pull`
19. Sprawdź obecny status repozytorium `git status`, sprawdź historię logów `git log`

# Zadanie 2 - Konflikt
1. Utwórz nowy branch "new_2" `git checkout -b <branch_name>`
2. Zmodyfikuj 2 istniejące pliki. Plik1 w 1 linii, Plik2 w 2 linii
3. `git add`  `git commit` 
4. Przejdź na branch "main" `git checkout`
5. modyfikuj 2 istniejące pliki. Plik1 w 1 linii, Plik2 w 3 linii
6. `git add`  `git commit` `git push`
7. Wróć na branch "new_2"
8. Scal branch "new_2" z branchem "main" `git merge `
9. KONFLIKT!
10. Rozwiąż konfilkt 
11. `git add`  `git commit` `git push`
