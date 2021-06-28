Этот файл лучше открыть отдельно, чтобы не потерять переносы

Для запуска нужен самозаверенный сертификат<br>
В PowerShell запустить по порядку<br>
$cert = New-SelfSignedCertificate -DnsName @("aspirant.test", "www.aspirant.test") -CertStoreLocation "cert:\LocalMachine\My"<br>
$certKeyPath = "c:\certs\aspirant.test.pfx"<br>
$password = ConvertTo-SecureString 'password' -AsPlainText -Force<br>
$cert | Export-PfxCertificate -FilePath $certKeyPath -Password $password<br>
$rootCert = $(Import-PfxCertificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root' -Password $password)<br>

Папку certs в C <u>не удалять!!!</u>
Запускать пока из студии

В файл hosts (C:/Windows/system32/drivers/etc) добавить строку <b>127.0.0.1 aspirant.test</b>

Пока только отображение некоторой информации.
Библиотеки <b>vue.js, bootstrap-vue</b> и вспомогательные для последней.

Ну и <u>dotnet build/dotnet run</u>.

В браузере заходить по ссылке <u>https://aspirant.test/</u>
