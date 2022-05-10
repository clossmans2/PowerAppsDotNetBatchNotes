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

// Arrays
// Array Literal Syntax
let beerIngredientsArray = ["Grains", "Water", "Yeast", "Hops", "Irish Moss"];
// New Array Syntax
let newArray = new Array();
// New Array with Defined Length 
let newArrayWithLengthDefined = new Array(10);
// New Array Syntax with stuff
let newArrWithItems = new Array("Apples", "Oranges", "Bananas", 4, undefined, true);
// Some array methods
beerIngredientsArray.length
newArrWithItems.push('Pear');
newArrWithItems.pop();
newArrWithItems.join(','); // Apples, Oranges, Bananas, 4, undefined, true, Pear
newArrWithItems.keys();
newArrWithItems.sort();
for (let index = 0; index < newArrWithItems.length; index++) {
    let fruit = newArrWithItems[index];
    console.log(fruit);
}
newArrWithItems[7];

// Number
let anIntButANumber = 10000.00;
let stringExample = "A string for example";

// Boolean
let boolExample1 = true;
let boolExample2 = false;
let boolExample3 = new Boolean();

// Symbol (ES6)
const s1 = Symbol();
const s2 = Symbol();
console.log(typeof s1);
console.log(s1===s2);
const s3 = Symbol("hello");
const s4 = Symbol("hello");
console.log(s3)
console.log(s4)
console.log(s3==s4)