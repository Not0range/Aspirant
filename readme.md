Для запуска нужен самозаверенный сертификат
В PowerShell запустить по порядку
$cert = New-SelfSignedCertificate -DnsName @("aspirant.test", "www.aspirant.test") -CertStoreLocation "cert:\LocalMachine\My"
$certKeyPath = "c:\certs\aspirant.test.pfx"
$password = ConvertTo-SecureString 'password' -AsPlainText -Force
$cert | Export-PfxCertificate -FilePath $certKeyPath -Password $password
$rootCert = $(Import-PfxCertificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root' -Password $password)

Папку certs в C <u>не удалять!!!</u>
Запускать пока из студии

В файл hosts (C:/Windows/system32/drivers/etc) добавить строку <b>127.0.0.1 aspirant.test</b>

Пока только отображение некоторой информации.
Библиотеки <b>vue.js, bootstrap-vue</b> и вспомогательные для последней.

Ну и <u>dotnet build/dotnet run</u>.

В браузере заходить по ссылке <u>https://aspirant.test/</u>