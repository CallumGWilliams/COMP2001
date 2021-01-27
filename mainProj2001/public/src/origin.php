<!DOCTYPE html>
<html>
<body>
<link rel="stylesheet" href="header.css">

<div class="smallHeader">
    <h1>ACTIVE LIBRARY USERS BY AGE IN PLYMOUTH, UK</h1>
</div>

    {
        "@context": "https://schema.org/",
        "@type": "Article",
        "name": "Active Library users by age",
        "description": "Plymouth, UK.",
        "about": {
            "@type": "Event",
            "name": "Library Ages Plymouth"
        },
        "contentReferenceTime": "2016-03-21T11:30:00-07:00"
    }

<?php

$myfile = fopen("csvjson.json", "r");

while(!feof($myfile)) {
    echo fgets($myfile) . "<br>";
}
fclose($myfile);
?>




