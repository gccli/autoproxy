include openresty.rc

all:openresty

OPENRESTY_VER=openresty-1.11.2.1
OPENRESTY_SRC=${OPENRESTY_VER}.tar.gz

openresty: $(NGINX_PATH)/sbin/nginx

$(NGINX_PATH)/sbin/nginx:${OPENRESTY_VER}/Makefile
	make -C ${OPENRESTY_VER}
	sudo make -C ${OPENRESTY_VER} install

${OPENRESTY_VER}/Makefile:
	$(call pre-build-nginx)


clean:
	rm -rf ${OPENRESTY_VER}
	rm -rf ${OPENRESTY_PATH}

define pre-build-nginx
	if [ ! -f ${OPENRESTY_SRC} ]; then \
	   wget https://openresty.org/download/${OPENRESTY_SRC}; \
	fi

	if [ ! -d $(OPENRESTY_VER) ]; then tar xzf $(OPENRESTY_SRC) -C .; fi
	cd $(OPENRESTY_VER) && ./configure --error-log-path=/var/log/nginx/nginx.log \
	  --http-log-path=/var/log/nginx/access.log

	sudo mkdir -p /var/log/nginx
	sudo chown -R nobody /var/log/nginx
endef
