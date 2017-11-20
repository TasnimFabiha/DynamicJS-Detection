<!DOCTYPE html>
<html>
<head>
	<title>User Information</title>
</head>
<body>

<p align="center">All Users Informations</p>

<?php
	
	session_start();

	$host = "localhost";
	$username = "root";
	$password = "";
	$db_name = "aps";
	$connection = mysqli_connect($host, $username, $password) or die("Host not connected");
	mysqli_select_db($connection, $db_name) or die("DB not selected");

	$sql = "SELECT * FROM user";
	$result = mysqli_query($connection,$sql);

	echo '<table align="center">
			<th>First Name</th>
			<th>Last Name</th>
			<th>Date Of Birth</th>
			<th>Gender</th>
			<th>Email</th>';

	while ($row = mysqli_fetch_assoc($result)) {

		echo '<tr>
				<td>'.$row['firstname'].'</td>
				<td>'.$row['lastname'].'</td>
				<td>'.$row['date_of_birth'].'</td>
				<td>'.$row['gender'].'</td>
				<td>'.$row['email'].'</td>
			</tr>';
	}

	echo '</table>';

?>

<br>

<p align="center"><a href="loginSuccess.php">Go Back</a></p>

</body>
</html>