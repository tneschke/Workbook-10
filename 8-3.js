/*jshint esversion: 6 */
// @ts-check

/* this is the driver program for Exercise 8-3 (Page 8, box 3)
 * you are allowed to modify it
 */

// these four lines fake out TypeScript into thinking that THREE
// has the same type as the T.js module, so things work for type checking
// type inferencing figures out that THREE has the same type as T
// and then I have to use T (not THREE) to avoid the "UMD Module" warning
/**  @type typeof import("./THREE/threets/index"); */
let T;
// @ts-ignore
T = THREE;

// get things we need
import { GrWorld } from "./Framework/GrWorld.js";
import {GrObject } from "./Framework/GrObject.js";  // only for typing
import * as Helpers from "./Libs/helpers.js";
import * as InputHelpers from "./Libs/inputHelpers.js";
import * as SimpleObjects from "./Framework/SimpleObjects.js";
import {shaderMaterial} from "./Framework/shaderHelper.js";

let image = new T.TextureLoader().load("./Textures/free-seamless-red-texture-vector.jpg");

/**
 * 
 * @param {GrObject} obj 
 * @param {number} [speed=1] - rotations per second
 */
function spinY(obj, speed=1) {
    obj.advance = function(delta,timeOfDay) {
        obj.objects.forEach(obj => obj.rotateY(speed*delta/1000*Math.PI));
    };
    return obj;
}

function test() {
    let mydiv = document.getElementById("8-3");

    let world = new GrWorld({width:(mydiv ? 600:800), where:mydiv});

    let objs = [];
    let dx = -6;

    let shaderMat = shaderMaterial("./Shaders/ex83.vs","./Shaders/ex83.fs",
        {
            side:T.DoubleSide,
            uniforms : {
                depth : {value: .4},
                colormap : {value: image}

            }
        });

    let s1 = new InputHelpers.LabelSlider("depth",  {width:400,min:0,max:1,step:0.1,initial:.4,where:mydiv});

    function onchange() {
        shaderMat.uniforms.depth.value = s1.value();
     }
    s1.oninput = onchange;
    onchange();

    world.add(spinY(new SimpleObjects.GrSphere({x:-2,y:1, widthSegments:100, heightSegments:100, material:shaderMat})));
    world.add(new SimpleObjects.GrSquareSign({x:2,y:1,size:1,material:shaderMat}));

    world.go();
}
Helpers.onWindowOnload(test);
