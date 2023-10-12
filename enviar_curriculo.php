<?php
require 'vendor/autoload.php'; 
require_once 'db_conn.php';

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['idPost'], $_POST['emailRemetente'])) {
        $idPost = $_POST['idPost'];
        $emailRemetente = $_POST['emailRemetente'];


        if (isset($_FILES['curriculo']) && $_FILES['curriculo']['error'] === UPLOAD_ERR_OK) {
            $nomeArquivo = $_FILES['curriculo']['name'];
            $caminhoTemporario = $_FILES['curriculo']['tmp_name'];

            $sqlEmail = "SELECT email FROM utilizador WHERE id = (SELECT utilizador_id FROM post WHERE id = '$idPost')";
            $resultadoEmail = $mysqli->query($sqlEmail);

            if ($resultadoEmail && $resultadoEmail->num_rows > 0) {
                $rowEmail = $resultadoEmail->fetch_assoc();
                $emailDestinatario = $rowEmail['email'];

                try {
                    $phpmailer = new PHPMailer();
                    $phpmailer->isSMTP();
                    $phpmailer->Host = 'smtp.gmail.com';
                    $phpmailer->SMTPAuth = true;
                    $phpmailer->Port = 587;
                    $phpmailer->Username = 'fastworktests@gmail.com';
                    $phpmailer->Password = 'eadrzblfzmtnbckr';

                    $phpmailer->setFrom($emailRemetente);
                    $phpmailer->addAddress($emailDestinatario);

                    $phpmailer->addAttachment($caminhoTemporario, $nomeArquivo);

                    $phpmailer->isHTML(true);
                    $phpmailer->CharSet = 'UTF-8';
                    $phpmailer->Subject = 'Envio de Currículo';
                    $tituloEmprego = $_POST['tituloEmprego'];
                    $phpmailer->Body = 'Olá, segue em anexo o meu currículo para a vaga de emprego "' . $tituloEmprego . '".';

                    echo '<div id="loading-overlay" class="visible">
                            <div class="c-loader"></div>
                          </div>';

                    $phpmailer->send();

                    echo '<script>window.location.href = "empregos.php"; stopLoading();</script>';
                    exit();
                } catch (Exception $e) {
                    echo 'Erro ao enviar o currículo: ' . $phpmailer->ErrorInfo;
                }
            } else {
                echo 'E-mail do destinatário não encontrado.';
            }
        } else {
            echo 'Erro ao fazer o upload do currículo: ' . $_FILES['curriculo']['error'];
        }
    } else {
        echo 'Todos os campos são obrigatórios.';
    }
} else {
    echo 'Erro ao processar o formulário.';
}
?>
