﻿let cats = [];let connection = -1;let catIDUpdated = -1;getData();setupSignalR();function setupSignalR() {	connection = new signalR.HubConnectionBuilder()		.withUrl(`http://localhost:32149/hub`)		.configureLogging(signalR.LogLevel.Information)		.build();	connection.on("CatCreated", (user, message) => {		getData();	});	connection.on("CatDeleted", (user, message) => {		getData();	});	connection.on("CatUpdated", (user, message) => {		getData();	});	connection.on("Cat_SitterCreated", (user, message) => {		getData2();	});	connection.on("Cat_SitterDeleted", (user, message) => {		getData2();	});	connection.on("Cat_SitterUpdated", (user, message) => {		getData2();	});	connection.on("Cat_OwnerCreated", (user, message) => {		getData3();	});	connection.on("Cat_OwnerDeleted", (user, message) => {		getData3();	});	connection.on("OwnerUpdated", (user, message) => {		getData3();	});	connection.onclose(async () => {		await start();	});	start();async function start() {	try {		await connection.start();		console.log("SignalR Connected.");	} catch (err) {		console.log(err);		setTimeout(start, 5000);	}};}async function getData() {	await fetch('http://localhost:32149/cat')		.then(x => x.json())		.then(y => {			cats = y		  // console.log(cats);			display();		});}function display() {	document.getElementById(`resultarea`).innerHTML = "";	cats.forEach(t => {		document.getElementById(`resultarea`).innerHTML +=			"<tr><td>" + t.cid + "</td><td>"		+ t.cat_Name + "</td><td>" +		`<button type="button" onclick="remove(${t.cid})">Delete</button>`+		`<button type="button" onclick="showupdate(${t.cid})">Update</button>`			+ "</td></tr>";			});}function remove(id) {	fetch('http://localhost:32149/cat/'+ id, {		method: 'DELETE',		headers: { 'Content-Type': 'application/json', },		body: null})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function showupdate(id) {	document.getElementById('updateformdiv').style.display = 'flex';	document.getElementById('updated_name')		.value = cats.find(t => t[`cid`] == id)[`cat_Name`];   catIDUpdated = id;}function update() {	document.getElementById('updateformdiv').style.display = 'none';	let cat_Name = document.getElementById('updated_name').value;	   fetch('http://localhost:32149/cat', {		method: 'PUT',		headers: { 'Content-Type': 'application/json', },		body: JSON.stringify(			{				cid: catIDUpdated,				cat_Name: cat_Name,			})	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function create() {	let cat_Name = document.getElementById(`cat_Name`).value;	fetch(`http://localhost:32149/cat`, {		method: `POST`,		headers: {'Content-Type' : 'application/json', },	body: JSON.stringify(		{			cat_Name: cat_Name,		})	})	.then(response => response)		.then(data =>		{			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}let catsitters = [];let catsitterIDUpdated = -1;getData2();async function getData2() {	await fetch('http://localhost:32149/cat_sitter')		.then(x => x.json())		.then(y => {			catsitters = y			display2();		});}function display2() {	document.getElementById(`resultarea2`).innerHTML = "";	catsitters.forEach(t => {		document.getElementById(`resultarea2`).innerHTML +=			"<tr><td>" + t.sid + "</td><td>"		+ t.sitter_Name + "</td><td>" +		+ t.sitter_Age + "</td><td>" +		+ t.its_salary_month + "</td><td>" + 			`<button type="button" onclick="remove2(${t.sid})">Delete</button>` +			`<button type="button" onclick="showupdate2(${t.sid})">Update</button>`			+ "</td></tr>";	});}function remove2(id) {	fetch('http://localhost:32149/cat_sitter/' + id, {		method: 'DELETE',		headers: { 'Content-Type': 'application/json', },		body: null	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function showupdate2(id) {	document.getElementById('updateformdiv2').style.display = 'flex';	document.getElementById('updated_sitter')		.value = catsitters.find(t => t[`sid`] == id)[`sitter_Name`];	document.getElementById('cat_Sitter_Ageu')		.value = catsitters.find(t => t[`sid`] == id)[`sitter_Age`];	document.getElementById('cat_Sitter_Salaryu')		.value = catsitters.find(t => t[`sid`] == id)[`its_salary_month`];	catsitterIDUpdated = id;}function update2() {	document.getElementById('updateformdiv2').style.display = 'none';	let cat_Sitter = document.getElementById('updated_sitter').value;	let cat_SitterA = document.getElementById('cat_Sitter_Ageu').value;	let cat_SitterS = document.getElementById('cat_Sitter_Salaryu').value;	fetch('http://localhost:32149/cat_sitter', {		method: 'PUT',		headers: { 'Content-Type': 'application/json', },		body: JSON.stringify(			{				sid: catsitterIDUpdated,				sitter_Name: cat_Sitter,				sitter_Age: cat_SitterA,				its_salary_month: cat_SitterS			})	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function create2() {	let cat_Sitter = document.getElementById(`cat_Sitter`).value;	let cat_Sitter_Age = document.getElementById(`cat_Sitter_Age`).value;	let cat_Sitter_Salary = document.getElementById(`cat_Sitter_Salary`).value;	fetch(`http://localhost:32149/cat_sitter`, {		method: `POST`,		headers: { 'Content-Type': 'application/json', },		body: JSON.stringify(			{				sitter_Name: cat_Sitter,				sitter_Age: cat_Sitter_Age,				its_salary_month: cat_Sitter_Salary			})	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}let catowners = [];let catownerIDUpdated = -1;getData3();async function getData3() {	await fetch('http://localhost:32149/cat_owner')		.then(x => x.json())		.then(y => {			catowners = y			display3();		});}function display3() {	document.getElementById(`resultarea3`).innerHTML = "";	catowners.forEach(t => {		document.getElementById(`resultarea3`).innerHTML +=			"<tr><td>" + t.oid + "</td><td>"			+ t.owner_Name + "</td><td>" +			+ t.owner_Age + "</td><td>" +			`<button type="button" onclick="remove3(${t.oid})">Delete</button>` +			`<button type="button" onclick="showupdate3(${t.oid})">Update</button>`			+ "</td></tr>";	});}function remove3(id) {	fetch('http://localhost:32149/cat_owner/' + id, {		method: 'DELETE',		headers: { 'Content-Type': 'application/json', },		body: null	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function showupdate3(id) {	document.getElementById('updateformdiv3').style.display = 'flex';	document.getElementById('updated_owner')		.value = catowners.find(t => t[`oid`] == id)[`owner_Name`];	document.getElementById('cat_Owner_Ageu')		.value = catowners.find(t => t[`oid`] == id)[`owner_Age`];	catownerIDUpdated = id;}function update3() {	document.getElementById('updateformdiv3').style.display = 'none';	let cat_Owner = document.getElementById('updated_owner').value;	let cat_OwnerA = document.getElementById('cat_Owner_Ageu').value;	fetch('http://localhost:32149/cat_owner', {		method: 'PUT',		headers: { 'Content-Type': 'application/json', },		body: JSON.stringify(			{				oid: catownerIDUpdated,				owner_Name: cat_Owner,				owner_Age: cat_OwnerA,			})	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}function create3() {	let cat_Owner = document.getElementById(`cat_Owner`).value;	let cat_Owner_Age = document.getElementById(`cat_Owner_Age`).value;	fetch(`http://localhost:32149/cat_owner`, {		method: `POST`,		headers: { 'Content-Type': 'application/json', },		body: JSON.stringify(			{				owner_Name: cat_Owner,				owner_Age: cat_Owner_Age,			})	})		.then(response => response)		.then(data => {			console.log('Success:', data);			getData2();		})		.catch((error) => { console.error('Error:', error); });}