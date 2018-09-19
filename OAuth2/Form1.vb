Public Class Form1

    Private WithEvents m_oauth2 As Chilkat.OAuth2 = Nothing

    Const facebookAuthEndpoint As String = "https://www.facebook.com/dialog/oauth"
    Const facebookTokenEndpoint As String = "https://graph.facebook.com/oauth/access_token"
    Const googleAuthorizationEndpoint As String = "https://accounts.google.com/o/oauth2/v2/auth"
    Const googleTokenEndpoint As String = "https://www.googleapis.com/oauth2/v4/token"
    Const linkedinAuthEndpoint As String = "https://www.linkedin.com/oauth/v2/authorization"
    Const linkedinTokenEndpoint As String = "https://www.linkedin.com/oauth/v2/accessToken"
    Const salesForceAuthEndpoint As String = "https://login.salesforce.com/services/oauth2/authorize"
    Const salesForceTokenEndpoint As String = "https://login.salesforce.com/services/oauth2/token"
    Const gitAuthEndpoint As String = "https://github.com/login/oauth/authorize"
    Const gitTokenEndpoint As String = "https://github.com/login/oauth/access_token"

    ' Replace these with actual values.
    Const facebookClientId As String = "FACEBOOK-CLIENT-ID"
    Const facebookClientSecret As String = "FACEBOOK-CLIENT-SECRET"

    Const googleAppClientId As String = "GOOGLE-CLIENT-ID"
    Const googleAppClientSecret As String = "GOOGLE-CLIENT-SECRET"

    Const linkedinClientId As String = "LINKEDIN-CLIENT-ID"
    Const linkedinClientSecret As String = "LINKEDIN-CLIENT-SECRET"

    Const salesForceClientId As String = "SALESFORCE-CLIENT-ID"
    Const salesForceClientSecret As String = "SALESFORCE-CLIENT-SECRET"

    Const gitClientId As String = "GITHUB-CLIENT-ID"
    Const gitClientSecret As String = "GITHUB-CLIENT-SECRET"


    ' When we're in a background thread, we should update UI elements in the foreground thread.
    Private Sub fgAppendToLog(s As String)
        Me.Invoke(DirectCast(Sub() textBox1.Text += s, MethodInvoker))
    End Sub

    Private Sub fgSetAccessToken(s As String)
        Me.Invoke(DirectCast(Sub() txtAccessToken.Text = s, MethodInvoker))
    End Sub

    Private Sub fgSetRefreshToken(s As String)
        Me.Invoke(DirectCast(Sub() txtRefreshToken.Text = s, MethodInvoker))
    End Sub


    ' Remember that TaskCompleted runs in a background thread.
    ' We cannot just update UI elements directly..
    Private Sub m_oauth2_OnTaskCompleted(sender As Object, args As Chilkat.TaskCompletedEventArgs) Handles m_oauth2.OnTaskCompleted

        fgAppendToLog("Task Completed.  Flow state = " + m_oauth2.AuthFlowState.ToString() + vbCr & vbLf)

        If m_oauth2.AuthFlowState = 3 Then
            ' Success!
            fgSetAccessToken(m_oauth2.AccessToken)

            ' Some providers, such as Facebook, do not provide a refresh token (and thus RefreshToken will be empty).
            fgSetRefreshToken(m_oauth2.RefreshToken)

            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("Access Granted")
            sb.AppendLine(m_oauth2.AccessTokenResponse)

            fgAppendToLog(sb.ToString())
        ElseIf m_oauth2.AuthFlowState = 4 Then
            ' Access Denied.  The user interactive choose to deny access (in the browser) rather than click on the "Allow" button.
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("Access Denied")
            sb.AppendLine(m_oauth2.AccessTokenResponse)
            fgAppendToLog(sb.ToString())
        Else
            ' Some other error happened and the OAuth2 did not complete.
            fgAppendToLog(m_oauth2.FailureInfo)
        End If
    End Sub


    Private Sub do_oauth2(p As OAuth2Params, bCodeChallenge As Boolean)
        Dim oauth2 As New Chilkat.OAuth2()

        oauth2.ListenPort = p.ListenPort

        oauth2.AuthorizationEndpoint = p.AuthorizationEndpoint
        oauth2.TokenEndpoint = p.TokenEndpoint
        oauth2.ClientId = p.ClientId
        oauth2.ClientSecret = p.ClientSecret
        oauth2.CodeChallenge = bCodeChallenge
        If (bCodeChallenge) Then
            oauth2.CodeChallengeMethod = "S256"
        End If
        If (p.Scope IsNot Nothing) AndAlso (p.Scope.Length > 0) Then
            oauth2.Scope = p.Scope
        End If

        ' Begin the OAuth2 flow.  Returns a URL that should be loaded in a browser.
        Dim url As String = oauth2.StartAuth()
        If url Is Nothing Then
            TextBox1.Text = oauth2.LastErrorText
            MessageBox.Show("StartAuth failed.")
            Return
        End If

        m_oauth2 = oauth2

        ' Start a web browser and load the url.
        ' This is where the end-user should accept or deny the authorization request.
        System.Diagnostics.Process.Start(url)

        ' Monitor for the OAuth2 completion.
        Dim task As Chilkat.Task = m_oauth2.MonitorAsync()
        If task Is Nothing Then
            MessageBox.Show("Failed to start monitoring.")
            Return
        End If

        ' Start the task.
        ' oauth2_OnTaskCompleted will be called when the end-user responds from the browser.
        task.Run()

        ' We're done with the .NET task object.
        ' The underlying (internal) Chilkat task is running in a background thread.
        ' Disposing of the .NET object does not affect the task that is running.
        ' It is important to dispose of .NET's reference to the underlying object so that
        ' when the task does complete, it is deallocated.  Otherwise, a reference
        ' to the underlying task remains and would only get removed when .NET
        ' garbage collects.
        task.Dispose()
        task = Nothing

        Return
    End Sub


    Private Sub clearTextBoxes()
        textBox1.Text = ""
        txtAccessToken.Text = ""
        txtRefreshToken.Text = ""
    End Sub

    Private Sub disposeOldOAuth2()
        ' If the m_oauth2 exists from a previous OAuth2 authorization,
        ' make sure it is disposed.
        If m_oauth2 IsNot Nothing Then
            m_oauth2.Dispose()
            m_oauth2 = Nothing
        End If
    End Sub


    Private Sub btnFacebook_Click(sender As Object, e As EventArgs) Handles btnFacebook.Click

        clearTextBoxes()
        disposeOldOAuth2()

        Dim p As New OAuth2Params()

        ' This matches the Site URL configured for our Facebook APP, which is "http://localhost:3017/"
        p.ListenPort = Convert.ToInt32(txtListenPort.Text)
        p.AuthorizationEndpoint = facebookAuthEndpoint
        p.TokenEndpoint = facebookTokenEndpoint
        p.ClientId = facebookClientId
        p.ClientSecret = facebookClientSecret

        ' Set the Scope to a comma-separated list of permissions the app wishes to request.
        ' See https://developers.facebook.com/docs/facebook-login/permissions/ for a full list of permissions.
        p.Scope = "public_profile,user_friends,email,user_posts,user_likes,user_photos"

        do_oauth2(p, True)

        Return
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim glob As New Chilkat.Global()
        If Not glob.UnlockBundle("Anything for 30-day trial") Then
            MessageBox.Show("Failed to unlock Chilkat.")
            TextBox1.Text = glob.LastErrorText
        End If

    End Sub

    Private Sub btnGoogle_Click(sender As Object, e As EventArgs) Handles btnGoogle.Click

        clearTextBoxes()
        disposeOldOAuth2()

        Dim p As New OAuth2Params()

        p.ListenPort = 0
        p.AuthorizationEndpoint = googleAuthorizationEndpoint
        p.TokenEndpoint = googleTokenEndpoint
        p.ClientId = googleAppClientId
        p.ClientSecret = googleAppClientSecret

        ' This is the scope for Google Drive.
        ' See https://developers.google.com/identity/protocols/googlescopes
        p.Scope = "https://www.googleapis.com/auth/drive"

        do_oauth2(p, True)

        Return
    End Sub

    Private Sub btnLinkedIn_Click(sender As Object, e As EventArgs) Handles btnLinkedIn.Click

        clearTextBoxes()
        disposeOldOAuth2()

        Dim p As New OAuth2Params()

        ' This should match the Authorized Redirect URL in your LinkedIn app, which would look like "http://localhost:3017/"
        p.ListenPort = Convert.ToInt32(txtListenPort.Text)
        p.AuthorizationEndpoint = linkedinAuthEndpoint
        p.TokenEndpoint = linkedinTokenEndpoint
        p.ClientId = linkedinClientId
        p.ClientSecret = linkedinClientSecret
        do_oauth2(p, False)

        Return
    End Sub

    Private Sub btnSalesForce_Click(sender As Object, e As EventArgs) Handles btnSalesForce.Click

        clearTextBoxes()
        disposeOldOAuth2()

        Dim p As New OAuth2Params()

        p.ListenPort = Convert.ToInt32(txtListenPort.Text)
        p.AuthorizationEndpoint = salesForceAuthEndpoint
        p.TokenEndpoint = salesForceTokenEndpoint
        p.ClientId = salesForceClientId
        p.ClientSecret = salesForceClientSecret
        do_oauth2(p, True)

        Return
    End Sub

    Private Sub btnGitHub_Click(sender As Object, e As EventArgs) Handles btnGitHub.Click

        clearTextBoxes()
        disposeOldOAuth2()

        Dim p As New OAuth2Params()

        p.ListenPort = Convert.ToInt32(txtListenPort.Text)
        p.AuthorizationEndpoint = gitAuthEndpoint
        p.TokenEndpoint = gitTokenEndpoint
        p.ClientId = gitClientId
        p.ClientSecret = gitClientSecret
        do_oauth2(p, True)

        Return
    End Sub
End Class
