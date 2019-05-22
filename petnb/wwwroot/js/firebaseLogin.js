

if (isSignedIn) {

    var user = firebase.auth().currentUser;
    if (user === null) {
        signIn();

    }
    initializeUser(userId, fullName);

}




function initializeUser(userId, fullName) {
    const usersRef = firebase.database().ref('Users/');

    usersRef.child(userId).once('value',
        function (snapshot) {
            if (snapshot.exists()) {
                alert('exists');
            } else {
                usersRef.child(userId).set(userId);
                usersRef.child(userId).set({
                    FullName: fullName

                });

            }
        });
}

function signIn() {
    firebase.auth().setPersistence(firebase.auth.Auth.Persistence.SESSION)
        .then(function () {
            // Existing and future Auth states are now persisted in the current
            // session only. Closing the window would clear any existing state even
            // if a user forgets to sign out.
            // ...
            // New sign-in will be persisted with session persistence.

            return firebase.auth().signInWithCustomToken(token);

        }).then(function () {
            user = firebase.auth().currentUser;

        })
        .catch(function (error) {
            // Handle Errors here.
            var errorCode = error.code;
            var errorMessage = error.message;
        });
}