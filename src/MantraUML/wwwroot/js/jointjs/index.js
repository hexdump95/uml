const graph = new joint.dia.Graph();

const paper = new joint.dia.Paper({
    el: document.getElementById('paper'),
    model: graph,
    defaultLink: () => new BaseLink(),
    linkPinning: false,
    validateConnection: function (cellViewS, magnetS, cellViewT, magnetT) {
        if (!magnetS || !magnetT) return false;

        var sourcePort = magnetS.getAttribute('port');
        var targetPort = magnetT.getAttribute('port');

        if (!sourcePort || !targetPort) return false;
        if (sourcePort === targetPort) return false;

        return true;
    }
});
