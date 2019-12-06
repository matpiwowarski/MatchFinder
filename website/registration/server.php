<?php
session_start();

// initializing variables
$username = "";
$email    = "";
$errors = array(); 

// connect to the database
$db = mysqli_connect('serwer1971603.home.pl', '31778368_matchfinderdb', 'tooeasyteam', '31778368_matchfinderdb');

// REGISTER USER
if (isset($_POST['reg_user'])) {
  // receive all input values from the form
  $username = mysqli_real_escape_string($db, $_POST['username']);
  $email = mysqli_real_escape_string($db, $_POST['email']);
  $password_1 = mysqli_real_escape_string($db, $_POST['password_1']);
  $password_2 = mysqli_real_escape_string($db, $_POST['password_2']);


  // form validation: ensure that the form is correctly filled ...
  // by adding (array_push()) corresponding error unto $errors array
  if (empty($username)) { array_push($errors, "Username is required."); }
  // \w is responsible for 'word character'
  else if (!preg_match('/^[\w]{3,19}$/', $username)){ array_push($errors, "Username must have number of characters beetwen
     4 and 20 and can contain only numbers, letters and '_' symbol."); }
  if (empty($email)) { array_push($errors, "Email is required"); }
  else if (!preg_match('/^([\S]+)*@([a-z0-9\-]+\.)+[a-z]{2,6}$/', $email))
  { array_push($errors, "Email address is incorrect."); }
  if (empty($password_1)) { array_push($errors, "Password is required."); }  
  // \S is responsible for no space character
  else if (!preg_match('/^[\S]{5,19}$/', $password_1)){ array_push($errors, "Password must have number of characters beetwen
    6 and 20 and can not contain spaces."); }
  if ($password_1 != $password_2) {
	array_push($errors, "The two passwords do not match.");
  }

  // first check the database to make sure 
  // a user does not already exist with the same username and/or email
  $user_check_query = "SELECT * FROM User WHERE username='$username' OR email='$email' LIMIT 1";
  $result = mysqli_query($db, $user_check_query);
  $user = mysqli_fetch_assoc($result);
  
  if ($user) { // if user exists
    if ($user['username'] === $username) {
      array_push($errors, "Username already exists.");
    }

    if ($user['email'] === $email) {
      array_push($errors, "Email already exists.");
    }
  }

  // Finally, register user if there are no errors in the form
  if (count($errors) == 0) {
  	$password = md5($password_1);//encrypt the password before saving in the database

  	$query = "INSERT INTO `User` (`id`, `email`, `password`, `nr_of_games`, `username`, `name`, `surname`, `City_id`, `Country_id`, `street`, `house_nr`, `create_time`)
     VALUES (NULL, '$email', '$password', '0', '$username', NULL, NULL, NULL, NULL, NULL, NULL, CURRENT_TIMESTAMP);";
  	mysqli_query($db, $query);
  	$_SESSION['username'] = $username;
  	$_SESSION['success'] = "You are now logged in.";
  	header('location: index.php');
  }
}

// LOGIN USER
if (isset($_POST['login_user'])) {
  $username = mysqli_real_escape_string($db, $_POST['username']);
  $password = mysqli_real_escape_string($db, $_POST['password']);

  if (empty($username)) {
  	array_push($errors, "Username is required.");
  }
  if (empty($password)) {
  	array_push($errors, "Password is required.");
  }

  if (count($errors) == 0) {
  	$password = md5($password);
  	$query = "SELECT * FROM User WHERE username='$username' AND password='$password'";
  	$results = mysqli_query($db, $query);
  	if (mysqli_num_rows($results) == 1) {
  	  $_SESSION['username'] = $username;
  	  $_SESSION['success'] = "You are now logged in.";
  	  header('location: index.php');
  	}else {
  		array_push($errors, "Wrong username/password combination.");
  	}
  }
}

?>