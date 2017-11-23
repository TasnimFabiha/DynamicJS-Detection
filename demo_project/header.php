<?php

session_start();


$host = "localhost";
$user = "root";
$pass = "";
$db = "sadid_project";
// Create connection
$conn = new mysqli($host, $user, $pass, $db);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}



if (isset($_POST['logout'])) {

//    session_destroy();
    $_SESSION['response'] = "Logged Out Successfully";
    $_SESSION['responseType'] = "success";

    $_SESSION['loggedIn'] = false;
    $_SESSION['username'] = "";
    $_SESSION['userId'] = "";
    $_SESSION['email'] = "";
    $_SESSION['phone'] = "";
}

if (isset($_POST['login'])) {
    if (!empty($_POST['username']) && !empty($_POST['password'])) {

        $sql = "SELECT * from users Where `username`='" . $_POST['username'] . "' and `password` = '" . $_POST['password'] . "'";
        $data = mysqli_query($conn, $sql) or die (mysqli_error($conn));
        if ($data->num_rows == 1) {
            foreach ($data as $row) {

                if ($_POST['username'] == $row['username'] && $_POST['password'] == $row['password']) {
                    $_SESSION['loggedIn'] = true;
                    $_SESSION['username'] = $row['username'];
                    $_SESSION['userId'] = $row['user_id'];
                    $_SESSION['email'] = $row['email'];
                    $_SESSION['phone'] = $row['phone'];
                    header("Location: ./index.php");

                } else {
                    $_SESSION['response'] = "Username or Password Incorrect";
                    $_SESSION['responseType'] = "error";
                }
            }
        } else {
            $_SESSION['response'] = "Username or Password Incorrect";
            $_SESSION['responseType'] = "error";
        }

    } else {

        $_SESSION['response'] = "Please provide correct information";
        $_SESSION['responseType'] = "error";

    }
}


if (isset($_POST['register'])) {
    if (!empty($_POST['username']) && !empty($_POST['email']) && !empty($_POST['password']) && !empty($_POST['passwordConfirm'])) {
        if (($_POST['password']) == ($_POST['passwordConfirm'])) {
            $sql = "INSERT INTO users (`username`,`email`,`password`,`phone`) VALUES('" . $_POST['username'] . "','" . $_POST['email'] . "','" . $_POST['password'] . "','" . $_POST['phone'] . "')";
            mysqli_query($conn, $sql) or die (mysqli_error($conn));;
            $_SESSION['response'] = "User registered Successfully";
            $_SESSION['responseType'] = "success";
        } else {
            $_SESSION['response'] = "Password and Confirm Password Mismatch";
            $_SESSION['responseType'] = "error";
        }

    } else {

        $_SESSION['response'] = "Please provide correct information";
        $_SESSION['responseType'] = "error";

    }

}


?>


<!DOCTYPE html>
<!--[if IE 8 ]>
<html class="ie ie8" lang="en"> <![endif]-->
<!--[if IE 9 ]>
<html class="ie ie9" lang="en"> <![endif]-->
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Sadid Project</title>
    <meta name="viewport"
          content="width=device-width, height=device-height, initial-scale=1, maximum-scale=1, user-scalable=no">



    <!-- CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/jquery-ui.min.css" rel="stylesheet">
    <link href="css/superfish.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/myApp.css" rel="stylesheet">
    <link href="fontello/css/fontello.css" rel="stylesheet">

</head>

<body>
<header>
    <div class="container">
        <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-3">
                <a href="" id=""><h4>Demo Project</h4></a>
            </div>
            <div class="col-md-9 col-sm-9 col-xs-9">
                <div class="pull-right">

                    <?php
                    if (isset($_SESSION['loggedIn'])) {
                        if ($_SESSION['loggedIn']) {
                            ?>


                            <form method="post" action="./login.php">
                                <a class="button_top" href="#">Hello, <?php echo $_SESSION['username']?></a>
                                <input type="hidden" name="logout" value="1" />
                                <button type="submit" class="button_top" id="login_top">Sign Out</button>

                            </form>


                            <?php
                        }else{
                            ?>
                            <a href="./register.php" class="button_top">Register</a>
                            <a href="./login.php" class="button_top" id="login_top">Sign in</a>
                            <?php
                        }
                    }else{
                        ?>
                        <a href="./register.php" class="button_top">Register</a>
                        <a href="./login.php" class="button_top" id="login_top">Sign in</a>
                    <?php
                    }
                    ?>

                </div>

            </div>
        </div>
    </div>
</header>
<!-- End header -->



<!-- End sub-header -->

