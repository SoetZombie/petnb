//var database = firebase.database()
//const messagesRef = firebase.database().ref('Messages')
//var usersMessages = [];

//function removeMsg (key){
// const toBeDeleted = firebase.database().ref('Messages/'+ key)
// toBeDeleted.remove();
//}
//function checkAuthor (key){
//usersMessages.indexOf(key) > -1 ? removeMsg(key) : alert('this is not your message')

//}
//function sendMessage (e) {
//  e.preventDefault()
//  var postData = {
//    author: userName,
//    message: document.getElementById('message').value
//  }
//  console.log(postData);
//  if(!(postData.message === null || postData.message.trim().length === 0)) {
//      messagesRef.push(postData).then((snap) => {
//          const key = snap.key
//          usersMessages.push(key)
//      });
//  document.getElementById('msgForm').reset();
//  }
//}

//messagesRef.on('value', gotData, errData)

//function createElement (element) {
//  document.createElement(element)
//}

//function gotData (data) {
//  const messages = data.val()
//  const keys = Object.keys(messages)
//  const list = document.createElement('ul')
//  const root = document.getElementById('allMessages')
//  root.appendChild(list)
//  if (root.childNodes.length > 2) {
//    root.removeChild(root.childNodes[1])
//  }

//  for (let i = 0; i < keys.length; i++) {
//    const k = keys[i]
//    const name = messages[k].author
//    const message = messages[k].message
//    const msgRoot = document.createElement('li')
//    msgRoot.setAttribute('class', 'msg')
//    msgRoot.innerHTML = `<b>${name}</b> says: ${message} `
//    const trash = document.createElement('div')
//    trash.setAttribute( 'value', k);
//    trash.setAttribute('class', 'trash far fa-trash-alt')
//    msgRoot.appendChild(trash)
//    list.appendChild(msgRoot)
//  }
//  attachEventListeners();
//}

//document.getElementById('msgForm').addEventListener('submit', sendMessage);
//document.getElementById('message').onkeydown = function(e) {
//    if(e.keyCode === 13) {
//        sendMessage(e);
        
//    }
//};
//function attachEventListeners(){
//  var deletingNodes = document.getElementsByClassName('trash');

//  for(let i = 0; i < deletingNodes.length; i++) {
//    deletingNodes[i].addEventListener('click', deleteMessage)
//  }
  
//}

//function deleteMessage(e){
//  var msgToBeDeleted = this;
//  var msgKey = msgToBeDeleted.getAttribute('value');
//  checkAuthor(msgKey);
//}

//function errData (err) {
//  console.error(`There was an error: ${err}`)
//} 