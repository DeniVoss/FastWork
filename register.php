<?php
require 'db_conn.php';

$errMsg = '';

if (isset($_POST['register'])) {

    $nome = $_POST['nome'];
    $apelido = $_POST['apelido'];
    $utilizador = $_POST['utilizador'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    $numero = $_POST['numero'];

    $stmt = $mysqli->prepare('SELECT id FROM utilizador WHERE utilizador = ?');
    $stmt->bind_param('s', $utilizador);
    $stmt->execute();
    $stmt->store_result();

    if ($stmt->num_rows > 0) {
        $errMsg = 'O nome de utilizador já existe.';
        $utilizador = ''; 
    } else {
        $stmt = $mysqli->prepare('SELECT id FROM utilizador WHERE email = ?');
        $stmt->bind_param('s', $email);
        $stmt->execute();
        $stmt->store_result();

        if ($stmt->num_rows > 0) {
            $errMsg = 'O email já existe';
            $email = ''; 
        } else {
            $stmt = $mysqli->prepare('INSERT INTO utilizador (nome, apelido, utilizador, email, password, numero) VALUES (?, ?, ?, ?, ?, ?)');
            $stmt->bind_param('sssssi', $nome, $apelido, $utilizador, $email, $password, $numero);
            $stmt->execute();
            $stmt->close();

            header('Location: login.php');
            exit;
        }
    }
}

if (isset($_GET['action']) && $_GET['action'] == 'joined') {
    $errMsg = 'Registration successful. Now you can <a href="login.php">login</a>';
}
?>



<!DOCTYPE html>
<html lang="en">
<head>
  <link rel="stylesheet" href="registercss.css">
  <title>FastWork Registar</title>
  <style>
    .error-message {
        color: red;
        font-weight: bold;
        margin-top: 5px;
    }
  </style>
</head>
<body>
    <video autoplay loop muted plays-inline class="back-video">
        <source src="imagens/videofundo.mp4" type="video/mp4">
    </video>  
    <section>
        <div class="form-box">
            <div class="form-value">
                <form method="POST" action="">
                    <h2>Registar</h2>
                    <?php if (!empty($errMsg)) { ?>
                        <p class="error-message"><?php echo $errMsg; ?></p>
                    <?php } ?>
                    <div class="inputbox">
                      <ion-icon name="person"></ion-icon>
                      <input type="text" required name="nome">
                      <label for="nome">Nome</label>
                    </div>
                    <div class="inputbox">
                      <ion-icon name="person"></ion-icon>
                      <input type="text" required name="apelido">
                      <label for="apelido">Apelido</label>
                    </div>
                    <div class="inputbox">
                        <ion-icon name="person"></ion-icon>
                        <input type="text" required name="utilizador">
                        <label for="Utilizador">Utilizador</label>
                    </div>
                    <div class="inputbox">
                        <ion-icon name="mail-outline"></ion-icon>
                        <input type="email" required name="email" value="<?php echo isset($email) ? $email : ''; ?>">
                        <label for="email">Email</label>
                    </div>
                    <div class="inputbox">
                        <ion-icon name="lock-closed-outline"></ion-icon>
                        <input type="password" required name="password">
                        <label for="password">Palavra-passe</label>
                    </div>
                    <div class="inputbox">
                        <ion-icon name="call-outline"></ion-icon>
                        <input type="number" required name="numero">
                        <label for="numero">Numero de Telemovel</label>
                    </div>
                    <button type="submit" name="register">Registar</button>
                    <div class="register">
                        <p>Ja tenho uma conta <a href="login.php">Entrar</a></p>
                    </div>
                </form>
            </div>
        </div>
    </section>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
    <script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>
</body>
</html>

