<?php
session_start();

include('db_conn.php');

if (isset($_COOKIE['lembrar_email']) && isset($_COOKIE['lembrar_password'])) {
    $email = $_COOKIE['lembrar_email'];
    $password = $_COOKIE['lembrar_password'];
} else {
    $email = '';
    $password = '';
}

if (isset($_POST['email']) && isset($_POST['password'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];
    $lembrar = isset($_POST['lembrar']) ? true : false;

    $sql = "SELECT id FROM utilizador WHERE email = ? AND password = ?";
    $stmt = $mysqli->prepare($sql);
    $stmt->bind_param("ss", $email, $password);
    $stmt->execute();
    $stmt->store_result();

    if ($stmt->num_rows == 1) {

        $stmt->bind_result($userId);
        $stmt->fetch();
        $_SESSION['utilizador'] = $userId;


        if ($lembrar) {
            setcookie('lembrar_email', $email, time() + (86400 * 30), "/");
            setcookie('lembrar_password', $password, time() + (86400 * 30), "/");
        } else {
            setcookie('lembrar_email', '', time() - 3600, "/");
            setcookie('lembrar_password', '', time() - 3600, "/");
        }

        header("Location: homepage2.php");
        exit();
    } else {
        $erro = "Email ou senha incorretos.";
    }

    $stmt->close();
}
?>

<html lang="en">
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="logincss.css">
    <title>FastWork login</title>
</head>
<body>
<?php
if (isset($erro) && is_array($erro)) {
    foreach ($erro as $msg) {
        echo "<p>$msg</p>";
    }
}
?>
<video autoplay loop muted plays-inline class="back-video">
    <source src="imagens/videofundo.mp4" type="video/mp4">
</video>
<section>
    <div class="form-box">
        <div class="form-value">
            <form action="login.php" method="POST">
                <h2>Login</h2>
                <div class="inputbox">
                    <ion-icon name="mail-outline"></ion-icon>
                    <input type="email" required name="email" value="<?php echo $email; ?>">
                    <label for="email">Email</label>
                </div>
                <div class="inputbox">
                    <ion-icon name="lock-closed-outline"></ion-icon>
                    <input type="password" required name="password" value="<?php echo $password; ?>">
                    <label for="password">Palavra-passe</label>
                </div>
                <div class="forget">
                    <label for=""><input type="checkbox" name="lembrar" <?php echo isset($_COOKIE['lembrar_email']) ? 'checked' : ''; ?>>Lembrar-me</label>
                </div>
                <div class="register">
                    <p>Sem conta? <a href="register.php">Registar</a></p>
                </div>
                <button type="submit">Log in</button>
            </form>
        </div>
    </div>
</section>
<script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</body>
</html>


