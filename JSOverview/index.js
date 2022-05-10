// Variables
var vegetaSays = "It's Over 9000!";
// Block Scoping when variable will change
let howCoolIsBeingCool = "Ice Cold!";
// Constant value
const theAnswer = 42;
// Technicall all above variables are global
// Globally available
window.myGlobalVar = theAnswer;

globallyscopedVar = "Dont do this!";

window.$
window.jQuery
var hitchhikerQuote;

// Variable scope
function globalScopeTest() {
    console.log(vegetaSays);
}
console.log(globalScopeTest()); // "It's Over 9000!"

howCoolIsBeingCool = "I said Ice Cold!";

function heyYa() {
    howCoolIsBeingCool = "Alright!Alright!Alright!Alright!Alright!Alright!Alright!";
}
console.log(howCoolIsBeingCool); // Value not modified until after function call
heyYa();
console.log(howCoolIsBeingCool); // Value changed after function call

// Locally (function) scoped variables
function dontPanic() {
    let hitchhikerQuote = "What is the ultimate answer to life, the universe, and everything? ";
    console.log(hitchhikerQuote + theAnswer);
}

dontPanic(); // "What is the ultimate answer to life, the universe, and everything? 42"

console.log(hitchhikerQuote + theAnswer); // Reference Error

let scope1 = "Let is block scoped!";

for (let index = 0; index < 10; index++) {
    // index only availble within block
    console.log(index);
}

console.log(index); // Reference error

// Objects, data types, type coercion
// JSON JavaScript Object Notation very similar
let myObj = {
    key1: "value1",
    key2: 2,
    "key3": false,
    key4: undefined,
    key5: null,
    key6: NaN,
    null: "Null key",
    undefined: "Undefined key",
    NaN: "NaN key",
    1: "Number key",
    getKey2: () => {
        return myObj.key2;
    },
    setKey2: (val) => {
        myObj.key2 = val;
    }
};
String(myObj["key3"]); // "false"
myObj.key1 = "new value 1";
myObj["null"];
myObj[1] = "number 1 property"; // Accesses the 1 key
myObj[2]; // Undefined
let myObj2;
let myObj3 = myObj;
Object.keys(myObj); // Keys only
Object.values(myObj); // Values only
Object.entries(myObj); // KVP of everything
Object.assign(myObj, myObj2); // Basically copying everything over
Object.defineProperty(myObj2, "key4", Symbol(3));
console.log(myObj.getKey2());
myObj.setKey2(56);
myObj.getKey2();

// New object method
let myOtherObj = new Object();
let trueObject = new Object(true); // {true}
let falseObject = new Object(Boolean); // {false}
let nullObject = new Object(null); // {null}
let undefObject = new Object(undefined); // {undefined}
let numObject = new Object(42); // {42}
// Again dont do this
// Self referencing property
let mySelfRefObj = {
    getInstance: function() {
        return mySelfRefObj;
    }
};

Object.create(Array).length === 1 // true
Object.keys(Object.create(Array)).length === 0 // true