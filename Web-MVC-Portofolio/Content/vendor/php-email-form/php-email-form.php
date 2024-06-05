<?php

class PHP_Email_Form
{
    public $to = 'me@mrizk.my.id'; // Ganti dengan alamat email penerima yang sebenarnya
    public $from_name;
    public $from_email;
    public $subject;
    public $message;
    public $headers;

    public function __construct()
    {
        $this->headers = "MIME-Version: 1.0" . "\r\n";
        $this->headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";
        $this->headers .= "From: $this->from_name <$this->from_email>" . "\r\n";
    }

    public function add_message($message, $label = '')
    {
        if ($label) {
            $this->message .= "<strong>$label:</strong> $message<br>";
        } else {
            $this->message .= "$message<br>";
        }
    }

    public function send()
    {
        if (mail($this->to, $this->subject, $this->message, $this->headers)) {
            return true;
        } else {
            return false;
        }
    }
}
