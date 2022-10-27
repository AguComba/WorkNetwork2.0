var $cont = document.querySelector('.cont');
var $elsArr = [].slice.call(document.querySelectorAll('.el'));
var $closeBtnsArr = [].slice.call(document.querySelectorAll('.el__close-btn'));

setTimeout(function () {
    $cont.classList.remove('s--inactive');
}, 200);

$elsArr.forEach(function ($el) {
    $el.addEventListener('click', function () {
        if (this.classList.contains('s--active')) return;
        $cont.classList.add('s--el-active');
        this.classList.add('s--active');
    });
});

$closeBtnsArr.forEach(function ($btn) {
    $btn.addEventListener('click', function (e) {
        e.stopPropagation();
        $cont.classList.remove('s--el-active');
        document.querySelector('.el.s--active').classList.remove('s--active');
    });
});

gsap.timeline({
    scrollTrigger: {
        trigger: ".box2",
        start: "top top",
        end: "bottom center",
        markers: false,
        scrub: true,
        pin: true
    }
})

    .from(".text1", { x: innerWidth * 2 })
    .from(".text2", { x: innerWidth * -1 })
    .from(".text3", { x: innerWidth * 2 })
    .from(".logo3", {
        y: innerHeight * 1,
     // rotate : 360
    })

gsap.timeline({
    scrollTrigger: {
        trigger: ".box3",
        start: "top top",
        end: "bottom center",
        markers: false,
        scrub: true,
        pin: true
    }
})

.from(".text4", { x: innerWidth * 1 })
.from(".text5", { x: innerWidth * -1 })
.from(".text6", { x: innerWidth * 1 })

let switchCtn = document.querySelector("#switch-cnt");
let switchCtn12 = document.querySelector("#switch-cnt12");
let switchC1 = document.querySelector("#switch-c1");
let switchC12 = document.querySelector("#switch-c12");
let switchC2 = document.querySelector("#switch-c2");
let switchC23 = document.querySelector("#switch-c23");
let switchCircle = document.querySelectorAll(".switch__circle");
let switchBtn = document.querySelectorAll(".switch-btn");
let aContainer = document.querySelector("#a-container");    
let aContainer12 = document.querySelector("#a-container12");
let bContainer = document.querySelector("#b-container");
let bContainer12 = document.querySelector("#b-container12");
let allButtons = document.querySelectorAll(".submit");
//let form13 = document.getElementById("b-form");
let getButtons = (e) => e.preventDefault()

let changeForm = (e) => {

    switchCtn.classList.add("is-gx");
    setTimeout(function () {
        //$('#b-form').addClass("visually-hidden");
        switchCtn.classList.remove("is-gx");
    }, 1500)

    switchCtn12.classList.add("is-gx");
    setTimeout(function () {
        //$('#b-form').addClass("visually-hidden");
        switchCtn12.classList.remove("is-gx");
    }, 1500)

        //$('#b-form').addClass("visually-hidden");
    switchCtn.classList.toggle("is-txr");
    switchCtn12.classList.toggle("is-txr");
    switchCircle[0].classList.toggle("is-txr");
    switchCircle[1].classList.toggle("is-txr");

    switchC1.classList.toggle("is-hidden");
    switchC12.classList.toggle("is-hidden");
    switchC2.classList.toggle("is-hidden");
    switchC23.classList.toggle("is-hidden");

    aContainer.classList.toggle("is-txl");
    aContainer12.classList.toggle("is-txl");
    bContainer.classList.toggle("is-txl");
    bContainer.classList.toggle("is-z200");
    bContainer12.classList.toggle("is-txl");
    bContainer12.classList.toggle("is-z200");


    //aContainer.classList.toggle("is-hidden");
    //bContainer12.classList.toggle("is-hidden");
}

let mainF = (e) => {
    for (var i = 0; i < allButtons.length; i++)
        allButtons[i].addEventListener("click", getButtons);
    for (var i = 0; i < switchBtn.length; i++)
        switchBtn[i].addEventListener("click", changeForm)
}

window.addEventListener("load", mainF);