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
console.log(s3);
console.log(s4);
console.log(s3==s4);


// Weird Type coercion (courtesy of https://wtfjs.com)
true + false; // 1
12 / "6"; // 2
"number" + 15 + 3; // number153
[1] > null; // true
"foo" + + "bar"; // fooNaN
"true" == true; // false
false == "false"; // false
null == ''; // false
true == !!"true"; // true
!!"false" == !!"true"; // true.
['x'] == 'x'; // true
[] + null + 1; // null1
[1,2,3] == [1,2,3] // false
{}+[]+{}+[1]; // 0[object Object]1
!+[]+[]+![]; // truefalse
new Date(0) - 0; // 0
new Date(0) + 0; // Wed Dec 31 1969 19:00:00 GMT-0500 (Eastern Standard Time)0'

// Type Checking
typeof(42) ;// number
typeof('String'); // string
typeof(undefined); // undefined
typeof(null); // object
typeof(NaN); // number
typeof(s1); // symbol

// window.setTimeout / window.clearTimeout
window.myIndexValue = 0;

function runAfter5secs() {
    window.myIndexValue++;
    console.log(window.myIndexValue);
    if (window.myIndexValue == 4) {
        window.clearTimeout(window.timeoutInstance);
    }
}

let millisecondsToWait = 5000;

window.timeoutInstance =
    window.setTimeout(runAfter5secs, millisecondsToWait);


window.setTimeout(() => {
    return console.log("Hello World");
}, 2000)


// window.setInterval / window.clearInterval

function runEvery3Seconds() {
    window.myIndexValue++;
    console.log(window.myIndexValue);
    if(window.myIndexValue == 10) {
        window.clearInterval(window.intervalInstance);
    }
}
window.intervalInstance = window.setInterval(runEvery3Seconds, 3000);

// Abstract or Loose Equality
// ==
false == 0; // true
0 == ""; // true
false = ""; //true 
// > undefined == true
// false
// > undefined == null
// true
// > undefined == undefined
// true
// > null == null
// true
// > 1 == null
// false
// > "help" == undefined
// false
// > NaN == NaN
// false
// > x = NaN
// NaN
// > x !== x
// true

// Strict equality
// No conversion, both values need to be same type or they are false
true === true; // true
true === 1; // false
false === 0; // false

// Callback
function filter(numbers, callback) {
    let results = [];
    for (const number of numbers) {
       if (callback(number)) {
           results.push(number)
       }
    }
    return results;
}

let numbers = [1,2,3,4,5,6];

let oddNumbers = filter(numbers, (number) => number % 2 != 0);

function evenCompare(number) {
    return number % 2 == 0
}
let evenNumbers2 = filter(numbers, evenCompare);

console.log(oddNumbers);
console.log(evenNumbers2);


function download(url) {
    setTimeout(() => {
        console.log(`Downloading ${url} ...`);
    }, 1000);
}

function process(picture) {
    console.log(`Processing ${picture}`);
}

let url1 = 'https://dog.ceo/api/breeds/image/random';

download(url1);
process(url1);

function download2(url, callback) {
    setTimeout(() => {
        console.log(`Downloading ${url} ...`);

        // run the callback function
        // process the picture
        callback(url);
    }, 1000);
}

// Events 
// Bubbling & capturing phases
{/* <element>.addEventListener(<eventName>, 
    <callbackFunction>, {capture : boolean}); */}
// See index.html

// Dom Manipulation
var myDiv = document.createElement('div'); // in memory not in dom yet

document.getElementsByTagName('div')[0].appendChild(myDiv);
myDiv.textContent = "Text content of a node";
myDiv.innerText = "Inner text of a node";
myDiv.innerHTML = "<p>My paragraph inside the div</p>";
document.getElementsByTagName('div')[0].insertBefore(myDiv);
var bigOleDiv = document.getElementById("outer-div");
bigOleDiv.replaceChild(myDiv);
bigOleDiv.remove();
bigOleDiv.firstElementChild.remove();
bigOleDiv.lastElementChild.remove();

// Style manipulation
bigOleDiv.style.backgroundColor = "magenta";
bigOleDiv.style.border = "2px solid";
bigOleDiv.style.width = "100px";
bigOleDiv.style.height = "100%";

bigOleDiv.className = "table";
bigOleDiv.classList.add("table", "table-striped", "table-hover");
bigOleDiv.classList.toggle("bg-info");
bigOleDiv.classList.contains("bg-warning");
// .replace() .remove()

// Prototypical Inheritance
const F = function() {
    this.a = 1;
    this.b = 2;
}

const O = new F(); // { a: 1, b: 2 }

F.prototype.b = 3;
F.prototype.c = 4;
F.prototype = { d: 5, e: 6 };


const O2 = {
    a: 2,
    m: function() {
        return this.a + 1;
    }
};

console.log(O2.m()); // 3
const p = Object.create(O2);
p.a = 4;
console.log(p.m()); // 5

function doSomething() {}
console.log( doSomething.prototype );

const doStuffArrowFunction = () => {};
console.log(doStuffArrowFunction.prototype); // undefined

doSomething.prototype.foo = 'bar';
const doSomethingInstance = new doSomething();
doSomethingInstance.prop = 'some value';
console.log(doSomethingInstance);


class Polygon {
    constructor(height, width){
        this.height = height;
        this.width = width;
    }
}

class Square extends Polygon {
    constructor(sideLength) {
        super(sideLength, sideLength);
    }

    get area() {
        return this.height * this.width;
    }

    set sideLength(newLength){
        this.height = newLength;
        this.width = newLength;
    }
}

const square = new Square(2);
console.log(square.area);

// Closures

function outerFunction(){
    // the outer scope
    let outerVar = "Outside variable";
    
    function innerFunc() {
        // inner scope
        console.log(outerVar); // Logs "Outside variable";
    }

    innerFunc();
}

outerFunction();

function outerFunction2(){
    // the outer scope
    let outerVar = "Outside variable";
    
    function innerFunc() {
        // inner scope
        console.log(outerVar); // Logs "Outside variable";
    }

    return innerFunc;
}

function exec() {
    const outerFunInside = outerFunction2();
    outerFunInside();
}

exec();

// Higher order functions
let vals = [1,2,3,4,5];

function doubleIt(x) {
    return x * 2;
}

vals.map(doubleIt);
console.log(vals)

vals = vals.fill(0).map(Math.random); // [0.923049751696241, 0.7800803983959783, 0.5933282059193838, 0.4971810798459193, 0.18859658804411228]

let vals2 = [1,2,3,4,5];
let sum = 0;
for (let val of vals2) {
    sum = sum + val;    
}
console.log(sum);

function isEven(num) {
    if (num % 2 == 0) {
        return num;
    }
}

let evenDigits = vals2.filter(num => isEven(num));
console.log(evenDigits);

let vals3 = [1, 42, 75, 313, 11 ,2, 83, 12, 9999, 6];
const comparisonFunction = (a,b) => {
    return a - b;
};
let sortedVals = vals3.sort(
    (a,b) => comparisonFunction(a,b)
);
console.log(sortedVals);

const xhr = new XMLHttpRequest();
let dogUrl = "https://dog.ceo/api/breeds/image/random";
let httpMethod = "GET";

xhr.open(httpMethod, dogUrl, true);
xhr.responseType = "json";
xhr.onreadystatechange = () => {
    if (xhr.readyState === XMLHttpRequest.DONE) {
        let status = xhr.status;
        if(status === 0 || (status >= 200 && status < 400)) {
            console.log(xhr.response);
        } else {
            console.log("An error occured!");
        }
    }
};

xhr.send();

//////////////////////////
var reqHeaders = new Headers();
reqHeaders.append('accept', 'application/json');
reqHeaders.append('Content-Type', 'application/json');
reqHeaders.append('X-RapidAPI-Host', 'matchilling-chuck-norris-jokes-v1.p.rapidapi.com');
reqHeaders.append('X-RapidAPI-Key', '3Ih2ExXrBwGSaRK6dERrdvoGuxIBZqQA');
const chuckNorrisApi = 'https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random';

const reqOptions = {
    method: 'GET',
    mode: 'cors',
    headers: reqHeaders
};

fetch(chuckNorrisApi, reqOptions)
    
    .then(resp => resp.json())
    .then(data => console.log(data.value))
    .catch((err) => {
        console.error(err);
    });


const myPromise = new Promise((resolve, reject) => {
    if (Math.random() * 100 < 10) {
        console.log("resolving the promise");
        resolve("Promise fulfilled");
    }
    reject( new Error('In 10% of cases, it fails. Miserably!'));
});

const onResolved = (resolvedValue) => console.log(resolvedValue);
const onRejected = (error) => console.log(error);

myPromise.then(onResolved, onRejected);

myPromise.then((resVal) => console.log(resVal), (error) => console.log(error));
///// Another library outside this one
var message;




///////////////////////////////////
///////// Typescript Intro ///////
///////////////////////////////////

message.toLowerCase();

message();

const message = "Hello World!";

function fn(x) {
    return x.flip();
}

fn(["hello world", 2, true]);

const user = {
    name: "Seth",
    age: "Old",
    location: undefined
};

user.location;

