function greet(person: string, date: Date): string {
    return `Hello ${person}, today is ${date}!`;
}

greet("Seth", new Date());


let msg = "hello"!

let numberOne = 1;

let trueVar: any = true;

let msg2: string = "hello again!";

let myObj: any = { a: 2, "key1": true };

console.log(greet("Taylor", new Date()));

const names = ["Seth", "Miles", "Dan"];
names.forEach((n) => {
    console.log(n.toUpperCase());
});

function printCoord(pt: { x: number, y: number }) {
    console.log(`The coordinates's x value is ${pt.x}`);
    console.log(`The coordinates's y value is ${pt.y}`);
}

printCoord({x: 10, y: -4});

function printName(obj: { first: string; last?: string }) {
    // let nameReturn: string = `Hi! My name is ${obj.first}`;
    // if (obj.last === null) {
    //     console.log(nameReturn);
    // }
    // else{
    //     nameReturn = nameReturn + obj.last;
    //     console.log(nameReturn);
    // }

    console.log(obj.first.toLocaleLowerCase() + " " + obj.last?.toLocaleUpperCase());
}

printName({first: "seth"});
printName({first: "seth", last: "clossman"});

type Address = string | number;

function printAddress(streetOrNumber: Address) {
    if (!!streetOrNumber) {
        
    }
    if (typeof streetOrNumber === "string") {
        streetOrNumber.toLowerCase()
    } else {
        streetOrNumber.toFixed()
    }

    console.log("Your street address or street number is " + streetOrNumber);
}

printAddress(190);
printAddress("Easy Street");

type Friend = string[] | string;

function welcomeFriends(x: Friend) {
    if (Array.isArray(x)) {
        x.forEach((name) => {
            console.log("Hello " + name + "!");
        });
    } else {
        console.log("Hello " + x + "!!");
    }
}

// type Point = {
//     x: number;
//     y: number;
// }

function printCoords2(pt: Point) {
    console.log(`The coordinates's x value is ${pt.x}`);
    console.log(`The coordinates's y value is ${pt.y}`);
}

interface Point {
    x: number;
    y: number;
}


interface Animal {
    name: string;
}

interface Bear extends Animal {
    hasHoney: boolean;
}

const bear: Bear = {
     hasHoney: true,
     name: "Pooh"
}

type Plane = {
    model: number
}

type Jet = Plane & {
    turbineCount: number
}

const boeing747: Jet = {
    model: 747,
    turbineCount: 4
}

interface Window {
    title: string
}

interface Window {
    version: number
}

const myCanvas = document.getElementById("drawing_canvas") as HTMLElement;

const x = "Rock Hill";

let expr = {};
//const a = (expr as any) as T;

function printText(s: string, alignment: "left" | "right" | "center") {

}

printText("Hello", "center");

function compare(a: string, b: string): -1 | 0 | 1 {
    return a === b ? 0 : a > b ? 1 : -1;
}
names.sort(compare);

enum Direction {
    Up = "W",
    Down = "S",
    Left = "A",
    Right = "D"
}

let mycontrol = Direction.Down;

function greeter(fn: GreetFunction) {
    fn("Hello world!");
}

function printToConsole(s: string) {
    console.log(s);
}

greeter(printToConsole);

type GreetFunction = (a: string) => void;


function firstElement<Type>(arr: Type[]): Type | undefined {
    return arr[0];
}

const fruit = firstElement(["apple", "orange", "donut"]);
let fruitArray = ["apple", "orange", "donut"];
firstElement(fruitArray);
 
class Point {
    x: number;
    y: number;

    constructor(x: number, y: number);
    constructor(s: string);
    constructor() {
        this.x = 0;
        this.y = 0;
    }
};
const pt = new Point(1, 2);
pt.x = 4;
pt.y = 5;

class Polygon {
    x: number;
    y: number;

    constructor(x: number, y: number);
    constructor(s: string);
    constructor() {
        this.x = 0;
        this.y = 0;
    }

    public getX()
    {
        return this.x
    };
}

class Square extends Polygon {
    constructor(sideLength: number) {
        super(sideLength, sideLength);
    }
}

class MyElement<Type> {
    contents: Type;
    
    constructor(val: Type) {
        this.contents = val;
    }
}

const myElem = new MyElement("myString");
console.log(myElem.contents);