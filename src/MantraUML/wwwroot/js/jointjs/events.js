paper.on('element:mouseenter', (evt) => {
    const type = $('.figure-selected').attr('id');
    if (!type) return;

    const element = evt.model;
    switch (type) {
        case 'class': {
            break;
        }
        default: {
            paper.freeze();
            highlightPortsByElement(element);
            paper.unfreeze();
            break;
        }
    }
});

paper.on('element:magnet:pointermove', (_a, _b, _c, x, y) => {
    const element = graph.getElements().filter(element => {
        const width = element.size().width;
        const height = element.size().height;
        const elx = element.position().x;
        const ely = element.position().y;
        return element.attributes.type === 'mantraUML.Class'
            && x <= 15 + elx + width
            && x >= -15 + elx
            && y <= 15 + ely + height
            && y >= -15 + ely
            ;
    })[0];
    if (element !== null && element !== undefined) {
        if (element !== portHighlightedElement) {
            paper.freeze();
            unhighlightPortsByElement(portHighlightedElement);
            highlightPortsByElement(element);
            paper.unfreeze();
        }
    }
});

paper.on('element:mouseleave', (evt) => {
    const type = $('.figure-selected').attr('id');
    const element = evt.model;
    if (type !== 'class') {
        paper.freeze();
        unhighlightPortsByElement(element);
        paper.unfreeze();
    }
});

paper.on('blank:pointerclick', (a, x, y) => {
    const type = $('.figure-selected').attr('id');

    if (type === 'class') {
        currentX = x;
        currentY = y;
        $('#field-count').val(0);
        $('#staticBackdrop').modal('show');
    } else {
        $('.btn-uml').removeClass('figure-selected');
    }

});

paper.on('link:connect', (lView, _a, _b) => {
    const link = lView.model;
    link.remove();

    const type = $('.figure-selected').attr('id');
    let newLink = LinkFactory.createLink(type);

    newLink.source(lView.sourceView.model, {port: link.attributes.source.port});
    newLink.target(lView.targetView.model, {port: link.attributes.target.port});
    if (lView.sourceView.model === lView.targetView.model) {
        newLink.router('manhattan');
    }

    graph.addCell(newLink);
    $('.btn-uml').removeClass('figure-selected');
});
