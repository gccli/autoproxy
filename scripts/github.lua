if ngx.req.get_method() == "GET" then
  ngx.say('This URI serve as Github Webhooks')
  return
end

ngx.req.read_body()
local data = ngx.req.get_body_data()
if data then
  local gevent = ngx.req.get_headers()["X-GitHub-Event"]
  if not gevent then
    ngx.say('Not a Github Webhook content content')
    return
  end

  local jobj = cjson.decode(data)
  local tab = {status='ok', length=string.len(data), event=gevent}
  if jobj.repository then
    tab.repository = jobj.repository.full_name
    ngx.log(ngx.INFO, "Event:", gevent, "repository", tab.repository)
  end
  ngx.say(cjson.encode(tab))
  return
else
  ngx.say("No body received")
end