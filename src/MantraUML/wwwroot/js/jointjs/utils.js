function measureText(svgDocument, text, attrs) {
    const vText = V('text').attr(attrs).text(text);
    vText.appendTo(svgDocument);
    const bbox = vText.getBBox();
    vText.remove();
    return bbox;
}

function getLongestTextWidth(title, attributes) {
    const svg = paper.svg;

    const measure = measureText(svg, title, {fontFamily: 'Verdana, sans-serif', fontSize: 13});
    let maxWidth = measure.width;

    attributes.forEach(attr => {
        const text = '- ' + attr.name + ': ' + attr.type;
        const width = measureText(svg, text, {fontFamily: 'Verdana, sans-serif', fontSize: 12}).width;
        if (width > maxWidth) {
            maxWidth = width;
        }
    });

    return maxWidth;
}

const getElementByLabel = (label) => {
    return graph.getElements().find(e => e.attributes.attrs['title'].text === label);
}
