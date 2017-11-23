<?php
session_start();
$username = isset($_SESSION['username'])?$_SESSION['username']:'';
$email = isset($_SESSION['email'])?$_SESSION['email']:'';
$phone = isset($_SESSION['phone'])?$_SESSION['phone']:'';

    echo "$(function () {
    e = $(\"\" +
        \"<h3>User Information</h3>\" +
        \"<h5>Username: ".$username."</h5>\" +
        \"<h5>Email: ".$email."</h5>\" +
        \"<h5>Phone: ".$phone."</h5>\");
    $(\"#effect\").html(e);
    var options = {};
    $(\"#effect\").effect(\"bounce\", options, 500);
});"
?>
