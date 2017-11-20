<!DOCTYPE html>
<html>
<head>
	<title>Menu</title>
</head>
<body>

<h2 align="center">Welcome</h2>

<?php

	session_start();

	$email = $_SESSION['login_email'];

	if ($email == "admin@aps.com") {
		
		echo '<p align="center">
				<a href="allUusersInformationView.php">View All Users Information</a>
				<a href="logout.php">Logout</a>
			</p>';
	}

	else{
		
		echo '<p align="center">
				<a href="userInformationView.php">View Information</a>
				<a href="logout.php">Logout</a>
			</p>';
	}

?>

</body>
</html>