mergeInto(LibraryManager.library, {

  GetNameInput: function (defaultInput) {
    var input = prompt(Pointer_stringify(defaultInput));
    console.log("input ", input);
    var n = input;
    if(n == null) n = "";
    gameInstance.SendMessage('WebGLInputField', 'GetNameInputCallBack', n);
  },
});