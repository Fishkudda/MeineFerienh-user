# MeineFerienhäuser


1.   Aufsetzen von ASP.net Core App. <br>
2.   Service erstellen zum Laden der Hausdaten aus der die aus dem Web kommt von https://img.dansk.de/challenge/house.json<br>
2.1. Einen Hash erstellen der die gleichheit der Daten im Speicher hinterlegt.<br>
2.2. Logik implementieren die Daten im Speicher abzudaten falls die JSON-Datei sich geändert hat.<br>
<br>
5.   Ein Haus Objekt für jedes Haus erstellen.<br>
6.   Eine Fabrik erstellen die für jedes Objekt Haus die Image links verwaltet und die links erstellt, die benötigt werden.<br>
4.1. Der Fabrik einen Validator hinzufügen der erreichbarkeit der Links überprüft in einem eigenen Task und dies alle X minuten wie in der Config hinterlegt.<br>
4.2. Einen Messageservice erstellen der eine E-Mail an X sendet falls ein Link ausgefallen ist um den Service zu informieren.<br>
4.3. Objekt Updater zur Fabrik hinzufügen der ein default Image lädt und den Kunden auf eine E-Mail des Service verweist, für weitere Informationen.<br>

7.   Die Basisseite mit Bootstrap 5 erstellen,<br>
5.1. Eine Basiccard erstellen für die Häuser.<br>
5.2. Die Karten mit Datenfüttern<br>
5.3. Bootstrapmagic benutzen für das Paging.<br>
5.4. Unter umständen Lazy load hinzufügen, falls 50+ Häuser pro Seite angezeigt werden. <br>     


Info:
https://hpix.dansk.de/[house.ImageUrl]?width=600
