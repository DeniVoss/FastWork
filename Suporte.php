<?php
session_start();
require 'vendor/autoload.php';
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

if (!isset($_SESSION['utilizador'])) {
    header("Location: login.php");
    exit();
}

if (isset($_GET['logout'])) {
    session_destroy();
    header("Location: login.php");
    exit();
}

$utilizadorID = $_SESSION['utilizador'];


require_once 'db_conn.php';

$query = "SELECT nome FROM utilizador WHERE id = $utilizadorID";
$result = $mysqli->query($query);

if ($result->num_rows > 0) {
    $row = $result->fetch_assoc();
    $nomeUtilizador = $row['nome'];
} else {
    $nomeUtilizador = "Nome do Utilizador";
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Dados do formulário
    $email = $_POST['email'];
    $titulo = $_POST['titulo'];
    $descricao = $_POST['descricao'];

    $host = 'localhost'; 
    $username = 'root'; 
    $password = ''; 
    $database = 'pap'; 

    $mysqli = new mysqli($host, $username, $password, $database);

    if ($mysqli->connect_error) {
        die('Erro na conexão com o banco de dados: ' . $mysqli->connect_error);
    }

    $sql = "INSERT INTO suporte (email, titulo, descricao) VALUES ('$email', '$titulo', '$descricao')";
    if ($mysqli->query($sql) === TRUE) {

        $mail = new PHPMailer;
        $mail->CharSet = 'UTF-8';
        $mail->isSMTP();
        $mail->Host = 'smtp.gmail.com';
        $mail->Port = 587;
        $mail->SMTPAuth = true;
        $mail->Username = '**************';//Ocultado por segurança
        $mail->Password = '***************';//Ocultado por segurança
        $mail->setFrom($email, 'Remetente'); 
        $mail->addAddress('**************'); //Ocultado por segurança
        $mail->Subject = 'Novo formulário de suporte';
        $mail->Body = "Email: $email\nTítulo: $titulo\nDescrição: $descricao";

        if (!$mail->send()) {
            echo 'Erro ao enviar o email: ' . $mail->ErrorInfo;
        } else {
            header('Location: suporte.php');
        }
    } else {
        echo 'Erro ao inserir os dados na base de dados: ' . $mysqli->error;
    }

    $mysqli->close();
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Formulário de Suporte</title>
    <link rel="stylesheet" type="text/css" href="suporte.css">
    <style>
        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
            text-align: center;
        }
    </style>
</head>
<body>
<div id="header">
    <a href="perfil.php" id="username"><?php echo $nomeUtilizador; ?></a>
    <h3 id="header-title">FastWork</h3>
    <a href="homepage2.php?logout=true" id="logout-btn">Logout</a>

</div>

<div id="navbar">
    <a href="homepage2.php">Home</a>
    <a href="empregos.php">Oferta Emprego</a>
    <a href="InserirEmprego.php">Inserir Emprego</a>
    <a href="suporte.php">Suporte</a>
</div>

<div class="container">
    <h1>Formulário de Suporte</h1>
    <form action="suporte.php" method="post">
        <label for="email">Email:</label><br>
        <input type="email" id="email" name="email" required><br><br>

        <label for="titulo">Título:</label><br>
        <input type="text" id="titulo" name="titulo" required><br><br>

        <label for="descricao">Descrição:</label><br>
        <textarea id="descricao" name="descricao" rows="5" required></textarea><br><br>

        <input type="submit" class="botaoS" value="Enviar">
    </form>
</div>
</body>
</html>
