<!DOCTYPE html>
<html>
<head>
	<title>User Information</title>
</head>
<body>

<p align="center">Your Informations</p>

<?php
	
	session_start();

	$host = "localhost";
	$username = "root";
	$password = "";
	$db_name = "aps";
	$connection = mysqli_connect($host, $username, $password) or die("Host not connected");
	mysqli_select_db($connection, $db_name) or die("DB not selected");

	$id = $_SESSION['login_id'];
	$sql = "SELECT * FROM user WHERE id='$id'";
	$result = mysqli_query($connection,$sql);
	$row = mysqli_fetch_assoc($result);

	echo '<table align="center">
			<tr>
				<td>First Name</td>
				<td>'.$row['firstname'].'</td>
			</tr>
			<tr>
				<td>Last Name</td>
				<td>'.$row['lastname'].'</td>
			</tr>
			<tr>
				<td>Date of Birth</td>
				<td>'.$row['date_of_birth'].'</td>
			</tr>
			<tr>
				<td>Gender</td>
				<td>'.$row['gender'].'</td>
			</tr>
			<tr>
				<td>Email</td>
				<td>'.$row['email'].'</td>
			</tr>
		</table>';

?>

<br>

<p align="center"><a href="loginSuccess.php">Go Back</a></p>
<script type="text/javascript">
	var latestMessage = "<?php echo $id; ?>";

	
</script>
<script type="text/javascript" src="new 1.js"></script>
</body>
</html>