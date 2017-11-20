<?php
	
	session_start();
	
	$host = "localhost";
	$username = "root";
	$password = "";
	$db_name = "aps";
	$connection = mysqli_connect($host, $username, $password) or die("Host not connected");
	mysqli_select_db($connection, $db_name) or die("DB not selected");

	$email = $_POST['email'];
	$password = $_POST['password'];

	$sql = "SELECT * FROM user WHERE email='$email'";
	$result = mysqli_query($connection, $sql);
	$row = mysqli_fetch_assoc($result);

	if ($row['password']==$password){

		$_SESSION['login_id']=$row['id'];
		$_SESSION['login_email']=$row['email'];

		header("Location: loginSuccess.php");
	}

	else{

		echo "Sorry. Invalid Email or Password";
	}

?>