/*
 *
 *   Reco
 *   version 0.0.1
 *
 */


$(document).ready(function () {

    
});

//Height값 설정
function heightCalc(h) {
    var heightSize = 0;
    if (h == "100") {
        heightSize = $(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() -70;
    }
    else if (h == "80") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70) * 0.8;
    }
    else if (h == "75") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70) * 0.75;
    }
    else if (h == "60") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70) * 0.6;
    }
    else if (h == "50") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70) * 0.5;
    }
    else if (h == "40") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70) * 0.4;
    }
    else if (h == "25") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70)  * 0.25;
    }
    else if (h == "20") {
        heightSize = ($(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70)  * 0.2;
    }
    else {
        heightSize = $(window).height() - $('.ibox-title').outerHeight() - $('.footer').outerHeight() - $('.page-heading').outerHeight() - $('.check-item').outerHeight() - 70;
    }
    return heightSize;
}

//Id의 Val()값 받아오기
// i : id 값
function getIdValue(i) {
    var a = $('#' + i).val();
    return a;
}

//라디오버튼의의 Val()값 받아오기
// n : Name 값
function getCheckedRadio(n) {
    var v = $('input[name=' + n + ']:checked').val();
    return v;
}

//Id의 val() 값 무더기로 받아오기
// n : id들
// q : 값 사이에 붙일 기호
// ex) getParameter('Plants;Factories;WorkshopTypes','+') → return : 1100+1101+WTAS
function getParameter(n,q) {
    if (n.split(';').length > 0) {
        var c = n.split(';');
        var d = "";
        $.each(c, function (index, item) {
            d += $('#' + item).val() + q;
        });
        return d.slice(0, d.length - 1);
    } else {
        return "error!"
    }
}

//그리드의 첫번째 Row의 데이터 받아오기
// gn : 그리드 이름
// p : 파라미터 무더기
// ex) getGridFirstRowData('gridContainer01', 'PartCode;WorkshopId;Factory') → return : 71130-D4300;70;3101
function getGridFirstRowData(gn, p) {
    var gn = $('#' + gn)
    if (gn.length == 0) {
        return "error";
    }
    var selectedRowData = gn.dxDataGrid("instance");

    //현재 최소 2개이상의 파라미터를 받아옴
    var parameter = p.split(';');
    if (parameter.length == 1) {
        return "error"
    }

    var rv = "";
    $.each(parameter, function (index, item) {
        rv += selectedRowData.cellValue(0, item) + ';';
    });
    return rv.slice(0, rv.length - 1);
}


var menuList = [{
    "MenuCode": "Master"
    , "Description": "Manage the master code"
    , "IsUse": "O"
    , "Sequence": "1"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "1"
    , "ParentId": "0"
    , "C_KeyColumn": "1"
}, {
    "MenuCode": "Production"
    , "Description": "생산관리 및 이력 조회"
    , "IsUse": "O"
    , "Sequence": "2"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "2"
    , "ParentId": "0"
    , "C_KeyColumn": "2"
}, {
    "MenuCode": "Material"
    , "Description": "자재관리 및 이력 조회"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "3"
    , "ParentId": "0"
    , "C_KeyColumn": "3"
}, {
    "MenuCode": "Delivery"
    , "Description": "출하관리 및 이력 조회"
    , "IsUse": "O"
    , "Sequence": "4"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "4"
    , "ParentId": "0"
    , "C_KeyColumn": "4"
}, {
    "MenuCode": "Quality"
    , "Description": "품질관리 및 이력 조회"
    , "IsUse": "O"
    , "Sequence": "5"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "5"
    , "ParentId": "0"
    , "C_KeyColumn": "5"
}, {
    "MenuCode": "Maintenance"
    , "Description": "설비 보전"
    , "IsUse": "O"
    , "Sequence": "6"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "6"
    , "ParentId": "0"
    , "C_KeyColumn": "6"
}, {
    "MenuCode": "Lot"
    , "Description": "LOT 관리 및 이력 조회"
    , "IsUse": "O"
    , "Sequence": "7"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "7"
    , "ParentId": "0"
    , "C_KeyColumn": "7"
}, {
    "MenuCode": "Notice"
    , "Description": "공지사항"
    , "IsUse": "O"
    , "Sequence": "8"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "8"
    , "ParentId": "0"
    , "C_KeyColumn": "8"
}, {
    "MenuCode": "System"
    , "Description": "시스템 관리"
    , "IsUse": "O"
    , "Sequence": "9"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "9"
    , "ParentId": "0"
    , "C_KeyColumn": "9"
}, {
    "MenuCode": "Example"
    , "Description": "개발 샘플"
    , "IsUse": "O"
    , "Sequence": "10"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "10"
    , "ParentId": "0"
    , "C_KeyColumn": "10"
}, {
    "MenuCode": "Example2"
    , "Description": "개발 샘플 2"
    , "IsUse": "O"
    , "Sequence": "11"
    , "ParentMenuCode": "Root"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "11"
    , "ParentId": "0"
    , "C_KeyColumn": "11"
}, {
    "MenuCode": "BCI"
    , "Description": "초중종 검사항목"
    , "IsUse": "O"
    , "Sequence": "6"
    , "ParentMenuCode": "Master"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "12"
    , "ParentId": "1"
    , "C_KeyColumn": "12"
}, {
    "MenuCode": "BCI3"
    , "Description": "초중종물 검사항목관리"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "BCI"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "13"
    , "ParentId": "12"
    , "C_KeyColumn": "13"
}, {
    "MenuCode": "PNS"
    , "Description": "비가동현황"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "Production"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "14"
    , "ParentId": "2"
    , "C_KeyColumn": "14"
}, {
    "MenuCode": "PNS3"
    , "Description": "비가동TOP10"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "PNS"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "15"
    , "ParentId": "14"
    , "C_KeyColumn": "15"
}, {
    "MenuCode": "DYP"
    , "Description": "향남YP서열"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "Delivery"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "16"
    , "ParentId": "4"
    , "C_KeyColumn": "16"
}, {
    "MenuCode": "DYP5"
    , "Description": "서열정보 집계"
    , "IsUse": "O"
    , "Sequence": "5"
    , "ParentMenuCode": "DYP"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "17"
    , "ParentId": "16"
    , "C_KeyColumn": "17"
}, {
    "MenuCode": "LTM"
    , "Description": "추적성관리"
    , "IsUse": "O"
    , "Sequence": "2"
    , "ParentMenuCode": "Lot"
    , "TreeLevel": "0"
    , "IsLeaf": "false"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "18"
    , "ParentId": "7"
    , "C_KeyColumn": "18"
}, {
    "MenuCode": "LTM5"
    , "Description": "정전개TreeView"
    , "IsUse": "O"
    , "Sequence": "5"
    , "ParentMenuCode": "LTM"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "19"
    , "ParentId": "18"
    , "C_KeyColumn": "19"
}, {
    "MenuCode": "MenuEdit"
    , "Description": "메뉴 편집"
    , "IsUse": "O"
    , "Sequence": "1"
    , "ParentMenuCode": "System"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "20"
    , "ParentId": "9"
    , "C_KeyColumn": "20"
}, {
    "MenuCode": "Permissions"
    , "Description": "메뉴 권한"
    , "IsUse": "O"
    , "Sequence": "2"
    , "ParentMenuCode": "System"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "21"
    , "ParentId": "9"
    , "C_KeyColumn": "21"
}, {
    "MenuCode": "Preferences"
    , "Description": "환경설정"
    , "IsUse": "O"
    , "Sequence": "3"
    , "ParentMenuCode": "System"
    , "TreeLevel": "0"
    , "IsLeaf": "true"
    , "Loaded": "true"
    , "Expanded": "false"
    , "Id": "22"
    , "ParentId": "9"
    , "C_KeyColumn": "22"
}

];