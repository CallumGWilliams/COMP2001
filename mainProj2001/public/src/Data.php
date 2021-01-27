<!DOCTYPE html>
<html>
<body>
<link rel="stylesheet" href="header.css">

<div class="smallHeader">
    <h1>ACTIVE LIBRARY USERS BY AGE IN PLYMOUTH, UK</h1>
</div>



<?php

echo "<html><body><table>\n\n";
$f = fopen("Library_Resources.csv", "r");
while (($line = fgetcsv($f)) !== false) {
    echo "<tr>";
    foreach ($line as $cell) {
        echo "<td>" . htmlspecialchars($cell) . "</td>";
    }
    echo "</tr>\n";
}
fclose($f);
echo "\n</table></body></html>";

?>

<iframe width="700" height="400" src="https://plymouth.thedata.place/dataset/active-library-users-by-age/resource/dde47275-1a23-402a-a40d-bba7d7c50955/view/1ced7fda-db93-4d9a-99f2-d695ffb759cc" frameBorder="0"></iframe>

