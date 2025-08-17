const graph = new joint.dia.Graph();

const paper = new joint.dia.Paper({
    el: $('#paper'),
    model: graph,
    defaultLink: () => new BaseLink(),
    linkPinning: false,
    snapLinks: {radius: 20},
    validateConnection: function (cellViewS, magnetS, cellViewT, magnetT) {
        if (!magnetS || !magnetT) return false;

        const sourcePort = magnetS.getAttribute('port');
        const targetPort = magnetT.getAttribute('port');

        if (!sourcePort || !targetPort) return false;
        if (sourcePort === targetPort) return false;

        return true;
    }
});

addDefsToSvg();

let currentX = 0;
let currentY = 0;
let attributeIds = [];

function submitClass() {
    const className = $('#class-name');
    const attributes = [];
    $('#tbody-attributes tr').each((index, _) => {
        attributes.push({
            visibility: $('#visibility-' + (attributeIds[index])).val(),
            name: $('#field-' + (attributeIds[index])).val(),
            type: $('#type-' + (attributeIds[index])).val(),
        });
    });

    const class_ = createClass({
        position: {x: currentX, y: currentY},
        label: className.val(),
        attributes: attributes,
    });
    graph.addCell(class_);
    $('#staticBackdrop').modal('hide');
    $('#tbody-attributes').empty();
    $('#field-count').val(0);
    className.val("");
    $('.btn-uml').removeClass('figure-selected');
    attributeIds = [];
}

function deleteSelectedTr(index) {
    attributeIds = attributeIds.filter(x => x !== index);
    $('#tr-' + index).remove();
}

function addAttributeField() {
    const fieldCount = $('#field-count');
    let index = parseInt(fieldCount.val()) + 1;
    fieldCount.val(index);
    attributeIds.push(index);

    console.log('tr-' + index);
    let html = '';
    html += '<tr id="tr-' + index + '">';

    html += '<td>';
    html += '<select class="form-select" aria-label="Visibility" id="visibility-' + index + '">';
    html += '<option selected value="-">private</option>';
    html += '<option value="+">public</option>';
    html += '<option value="#">protected</option>';
    html += '</select>';

    html += '<td>';
    html += '<input type="text" class="form-control" id="field-' + index + '" placeholder="Attribute">';
    html += '</td>';

    html += '<td>';
    html += '<select class="form-select" aria-label="Type" id="type-' + index + '">';
    html += '<option selected value="String">String</option>';
    html += '<option value="Integer">Integer</option>';
    html += '<option value="Long">Long</option>';
    html += '<option value="Float">Float</option>';
    html += '<option value="Double">Double</option>';
    html += '<option value="Instant">Instant</option>';
    html += '</select>';
    html += '<td>';

    html += '<td>';
    html += '<button class="btn btn-danger" onclick="deleteSelectedTr(' + index + ')">-</button>';
    html += '</td>';

    html += '</tr>';
    $('#tbody-attributes').append(html);
}

let portHighlightedElement;

function highlightPortsByElement(element) {
    portHighlightedElement = element;
    element.getPorts().forEach(p => {
        element.portProp(p.id, 'attrs/portBody/r', 5);
    });
}

function unhighlightPortsByElement(element) {
    element.getPorts().forEach(p => {
        element.portProp(p.id, 'attrs/portBody/r', 0);
    });
}

function prepareFigure(button) {
    if (!$(button).hasClass('figure-selected')) {
        $('.btn-uml').removeClass('figure-selected');
        $(button).addClass('figure-selected');
    } else {
        $('.btn-uml').removeClass('figure-selected');
    }
}
