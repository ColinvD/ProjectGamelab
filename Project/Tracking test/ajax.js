function ajax(action, data) {
  let controlScript = "jsonWrite.php";
  let jsonFile = "drawing.json";
  if (window.XMLHttpRequest) { // code for IE7+, Firefox, Chrome, Opera, Safari
    xmlhttp = new XMLHttpRequest();
  } else {
    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
  }
  if(action == "putJson"){
    let httpString = controlScript + "?put=" + data;
    xmlhttp.open("GET", httpString, true);
    xmlhttp.send();
    xmlhttp.onreadystatechange = function(){
    }
  }
}
