<?php

	$host = "localhost";
	$username = "root";
	$password = "";
	$db_name = "aps";
	$connection = mysqli_connect($host, $username, $password) or die("Host not connected");
	mysqli_select_db($connection, $db_name) or die("DB not selected");


	if(isset($_POST['submit'])){

		$firstname =  $_POST['firstname'];
		$lastname =  $_POST['lastname'];
		$dob =  $_POST['dob'];
		$gender =  $_POST['gender'];
		$email = $_POST['email'];
		$password = $_POST['password'];

		$sql = "SELECT email FROM user WHERE email='$email'";
		$result = mysqli_query($connection, $sql);

		if (mysqli_fetch_assoc($result)) {
			echo 'Sorry';
		}

		else{


			$sql = "INSERT INTO user (firstname, lastname, date_of_birth, gender, email, password) VALUES ('$firstname', '$lastname', '$dob', '$gender', '$email', '$password')";
			$result = mysqli_query($connection, $sql);


			if ($result) {

	    		header("Location: login.html");
				die();
	  		} 

			else { 
	    
	   			echo "Sorry. Registration Failed";
			}
		}
}

?>