Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Net.Mail
Imports System.Net

<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://ginie.live/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Msg
    Inherits System.Web.Services.WebService
    Dim GmailFromId As String = "Care.Ginie@gmail.com"
    Dim GmailFromName As String = "Support GITI"
    Dim GmailAppKey As String = "tqlovkniyhvjdkza"

    Dim FromId As String = "support@ginie.live"
    Dim FromName As String = "Support MahaEgov"
    Dim FromPswd As String = "Daddy@2020"

    Dim AuthKey As String = "JaiMataDi@Jammu"

    <WebMethod()>
    Public Function AskHelloWorld() As String
        Return "Hello World, How are you?"
    End Function

    <WebMethod()>
    Public Function Email(ByVal EmailId As String, ByVal Subject As String, ByVal Message As String,
                              ByVal Sender As String, ByVal Appkey As String) As String
        Dim smtpClient As New SmtpClient("smtpout.secureserver.net")
        smtpClient.Port = 587 ' Use 465 if you require SSL
        smtpClient.Credentials = New NetworkCredential(FromId, FromPswd)
        smtpClient.EnableSsl = False

        Dim mailMessage As New MailMessage()
        mailMessage.From = New MailAddress(FromId, FromId)
        mailMessage.To.Add("saimbhi261@gmail.com")
        mailMessage.Subject = "Ticket Sent from Server at " & Now.ToString("hh:mm:ss tt")
        mailMessage.Body = "Message Sent from live server with reference Number " & Guid.NewGuid().ToString
        mailMessage.IsBodyHtml = True
        Dim result As String = "Pass"
        Try
            smtpClient.Send(mailMessage)
            result = "Sent"
        Catch ex As SmtpException
            result = "Fail:Error is " & ex.Message
        End Try
        Return result

    End Function

    '<WebMethod()>
    'Public Function Email2(ByVal EmailId As String, ByVal Subject As String, ByVal Message As String,
    '                          ByVal Sender As String, ByVal Appkey As String) As String
    '    If Appkey <> AuthKey Then
    '        Return "Fail:Invalid Google AppKey"
    '    End If
    '    Dim toAddress As New MailAddress(EmailId)
    '    Dim fromAddress As New MailAddress(FromId, FromName)
    '    Dim smtp As New SmtpClient()
    '    smtp.Host = "smtpout.secureserver.net"
    '    smtp.Port = 587
    '    smtp.EnableSsl = False
    '    smtp.UseDefaultCredentials = False
    '    smtp.Credentials = New NetworkCredential(fromAddress.Address, FromPswd)
    '    Dim msg As New MailMessage(fromAddress, toAddress)
    '    msg.Subject = Subject
    '    msg.Body = Message
    '    msg.IsBodyHtml = True
    '    Dim result As String = "Pass"
    '    Try
    '        smtp.Send(msg)
    '        result = "Sent"
    '    Catch ex As SmtpException
    '        result = "Fail:Error is " & ex.Message
    '    End Try
    '    Return result
    'End Function


    '<WebMethod()>
    'Public Function Gmail(ByVal EmailId As String, ByVal Subject As String, ByVal Message As String,
    '                          ByVal Sender As String, ByVal Appkey As String) As String
    '    If Appkey <> AuthKey Then
    '        Return "Fail:Invalid AppKey"
    '    End If
    '    Dim toAddress As New MailAddress(EmailId)
    '    Dim fromAddress As New MailAddress(FromId, FromName)
    '    Dim gMailAppKey As String = gMailAppKey
    '    Dim smtp As New SmtpClient()
    '    smtp.Host = "smtp.gmail.com"
    '    smtp.Port = 25
    '    smtp.EnableSsl = False
    '    smtp.UseDefaultCredentials = False
    '    smtp.Credentials = New NetworkCredential(fromAddress.Address, gMailAppKey)
    '    Dim msg As New MailMessage(fromAddress, toAddress)
    '    msg.Subject = Subject
    '    msg.Body = Message
    '    msg.IsBodyHtml = True
    '    Dim result As String = "Pass"
    '    Try
    '        smtp.Send(msg)
    '    Catch ex As SmtpException
    '        result = "Fail:Error is " & ex.Message
    '    End Try
    '    Return result
    'End Function

    '<WebMethod()>
    'Public Function Sms(ByVal MobileNo As String, ByVal Message As String) As String
    '    Try
    '        ' Replace with your email sending logic
    '        ' Example: EmailHelper.Send(emailTo, emailSubj, emailBody)

    '        ' For now, returning "Pass" as a placeholder
    '        Return "Pass"
    '    Catch ex As Exception
    '        ' Log exception if needed
    '        Return "Fail"
    '    End Try
    'End Function

End Class