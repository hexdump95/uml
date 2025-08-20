let selectElements = [];

paper.on('cell:contextmenu', (eV) => {
    if (selectElements.findIndex(i => i === eV.model) !== -1) {
        console.log('displayMenu');
    }
});

paper.on('blank:pointerdown', (evt) => {
    if (!evt.shiftKey && !evt.ctrlKey) {
        unselectAllElements();
    }
});

paper.on('cell:pointerdown', (eV, evt) => {
    if (!evt.shiftKey && !evt.ctrlKey) {
        unselectAllElements();
    }
    if (selectElements.findIndex(i => i === eV.model) === -1) {
        addSelectedElement(eV.model);
    } else {
        removeSelectedElement(eV.model);
    }

});

function unhighlightElement(element) {
    if (element.attributes.type === 'mantraUML.Class') {
        element.attr('body/stroke', '#000');
        element.attr('body/strokeWidth', 1);
    } else {
        element.attr('line/stroke', '#000');
        element.attr('line/strokeWidth', 1);
        element.attr('line/targetMarker/stroke-width', 1);
        element.attr('line/sourceMarker/stroke-width', 1);
    }
}

function highlightElement(element) {
    if (element.attributes.type === 'mantraUML.Class') {
        element.attr('body/stroke', '#900600');
        element.attr('body/strokeWidth', 3);
    } else {
        element.attr('line/stroke', '#900600');
        element.attr('line/strokeWidth', 3);
        element.attr('line/targetMarker/stroke-width', 3);
        element.attr('line/sourceMarker/stroke-width', 3);
    }
}

function unhighlightAllElements() {
    selectElements.forEach(element => {
        unhighlightElement(element);
    });
}

function unselectAllElements() {
    unhighlightAllElements();
    selectElements = [];
}

function removeSelectedElement(element) {
    selectElements = selectElements.filter(i => i !== element);
    unhighlightElement(element);
}

function addSelectedElement(element) {
    selectElements.push(element);
    highlightElement(element);
}
