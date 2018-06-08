<?php
  $debug = true;
  $control = "";
  $filePath = "drawing.json";
  if(!empty($_GET['put'])){
    $control = $_GET['put'];
  }
  $file = fopen($filePath, "w") or die("can't open file");
  fwrite($file, $control);
  fclose($file);
?>
