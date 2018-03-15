function FindProxyForURL(url, host) {
    var localproxy = 'PROXY 127.0.0.1:8844';
    var vpnproxy = 'PROXY 127.0.0.1:10080;PROXY 192.168.88.1:10080';
    var comp = "DIRECT;"+vpnproxy;

    var patterns = {
        'google': vpnproxy,
        'gstatic': vpnproxy,
        'wikipedia': vpnproxy,
        'docker.com$': vpnproxy,
        'golang.org$': vpnproxy,
        'youtube.com': vpnproxy
    };

    for (var regex in patterns) {
        if (host.match(regex)) {
            console.log(host);
            return patterns[regex];
        }
    }

    return comp;
}
