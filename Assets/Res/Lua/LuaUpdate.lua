LuaUpdate = BaseClass("LuaUpdate")
LuaUpdate.UpdateHandler = nil


function LuaUpdate:EnableUpdate(_enable)
    if _enable == true then
        LuaUpdate.UpdateHandler = self.Update or nil
    end
end

function LuaUpdate:Start()
      print("luaupdate start...")
end

function Update()
    print("Update")
    if LuaUpdate.UpdateHandler ~= nil then
        LuaUpdate:UpdateHandler()
    end
end

function LuaUpdate:RemoveEnable()
    LuaUpdate.UpdateHandler = nil
end


return LuaUpdate